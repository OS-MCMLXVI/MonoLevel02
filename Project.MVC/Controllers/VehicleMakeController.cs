using Project.MVC.ViewModels;
using Project.Service;
using Project.Service.DAL;
using Project.Service.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Project.MVC.Controllers
{
      public class VehicleMakeController : Controller
      {
            VehicleContext _context;
            VehicleService<VehicleMake> _service;


            public VehicleMakeController()
            {
                  this._context = new VehicleContext();
                  this._service = new VehicleService<VehicleMake>(this._context);
            }


            #region Index

            public ActionResult Index()
            {
                  List<VehicleMakeVM> viewList = new List<VehicleMakeVM>();
                  var sourceList = _service.GetAll();

                  foreach (var make in sourceList)
                  {
                        viewList.Add(new VehicleMakeVM
                        {
                              MakeId = make.Id,
                              MakeName = make.Name
                        });
                  }

                  return View(viewList);
            }

            #endregion


            #region Create

            public ActionResult Create()
            {
                  return View(new VehicleMakeVM());
            }

            [HttpPost]
            public ActionResult Create(VehicleMakeVM objToCreate)
            {
                  try
                  {
                        if (ModelState.IsValid)
                        {
                              _service.Insert(new VehicleMake { Id = objToCreate.MakeId, Name = objToCreate.MakeName });
                              _context.SaveChanges();

                              return RedirectToAction("Index");
                        }

                        return View();
                  }
                  catch
                  {
                        return View();
                  }
            }

            #endregion


            #region Details

            public ActionResult Details(int id)
            {
                  var objToView = _service.GetById(id);
                  return View(new VehicleMakeVM { MakeId = objToView.Id, MakeName = objToView.Name });
            }

            #endregion


            #region Edit

            public ActionResult Edit(int id)
            {
                  var objToEdit = _service.GetById(id);
                  return View(new VehicleMakeVM { MakeId = objToEdit.Id, MakeName = objToEdit.Name });
            }

            [HttpPost]
            public ActionResult Edit(VehicleMakeVM objToEdit)
            {
                  try
                  {
                        if (ModelState.IsValid)
                        {
                              _service.Update(new VehicleMake { Id = objToEdit.MakeId, Name = objToEdit.MakeName });
                              _context.SaveChanges();

                              return RedirectToAction("Index");
                        }

                        return View();
                  }
                  catch
                  {
                        return View();
                  }
            }

            #endregion


            #region Delete

            public ActionResult Delete(int id)
            {
                  var objToDelete = _service.GetById(id);
                  return View(new VehicleMakeVM { MakeId = objToDelete.Id, MakeName = objToDelete.Name });
            }

            [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int id)
            {
                  try
                  {
                        _service.Delete( id );
                        _context.SaveChanges();

                        return RedirectToAction("Index");
                  }
                  catch
                  {
                        return View();
                  }
            }

            #endregion

      }
}