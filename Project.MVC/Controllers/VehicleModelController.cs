using AutoMapper;
using PagedList;
using Project.MVC.ViewModels;
using Project.Service;
using Project.Service.DAL;
using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Project.MVC.Controllers
{
      public class VehicleModelController : Controller
      {
            VehicleContext _context;
            VehicleService<VehicleModel> _service;


            public VehicleModelController()
            {
                  this._context = new VehicleContext();
                  this._service = new VehicleService<VehicleModel>(this._context);
            }


            #region Index

            public ActionResult Index(int id, string sortOrder, string currentSortOrder, int? page)
            {
                  // Source data, default sort -> ascending
                  var sourceList = _service.GetAll().Where(x => x.MakeId == id).OrderBy(s => s.Name).OrderBy(s => s.Name);
                  ViewBag.ID = id;


                  // Sort...
                  ViewBag.SortOrder = String.IsNullOrEmpty(sortOrder) ? "descend" : "";

                  if (currentSortOrder != sortOrder)
                  {
                        ViewBag.CurrentSortOrder = sortOrder;

                        if (sortOrder == "descend")
                              sourceList = sourceList.OrderByDescending(s => s.Name);
                  }


                  // Data mapping...
                  var mapperConfig = new MapperConfiguration(cfg => { cfg.CreateMap<VehicleModel, VehicleModelVM>(); });
                  var mapiranje = new Mapper(mapperConfig);
                  var viewList = new List<VehicleModelVM>();

                  foreach (var model in sourceList)
                        viewList.Add(mapiranje.Map<VehicleModelVM>(model));


                  // Paging...
                  int pageSize = 5;
                  int pageNumber = (page ?? 1);
                  return View(viewList.ToPagedList(pageNumber, pageSize));
            }

            #endregion

            
            #region Create

            public ActionResult Create(int id)
            {
                  return View(new VehicleModelVM { MakeId = id });
            }

            [HttpPost]
            public ActionResult Create(VehicleModelVM objToCreate)
            {
                  try
                  {
                        if (ModelState.IsValid)
                        {
                              _service.Insert(new VehicleModel { Name = objToCreate.Name, MakeId = objToCreate.MakeId });
                              _context.SaveChanges();

                              return RedirectToAction("Index", new { id = objToCreate.MakeId });
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
                  return View(new VehicleModelVM { Id = objToView.Id, Name = objToView.Name, MakeId = objToView.MakeId });
            }

            #endregion

            
            #region Edit

            public ActionResult Edit(int id)
            {
                  var objToEdit = _service.GetById(id);
                  return View(new VehicleModelVM { Id = objToEdit.Id, Name = objToEdit.Name, MakeId = objToEdit.MakeId });
            }

            [HttpPost]
            public ActionResult Edit(VehicleModelVM objToEdit)
            {
                  try
                  {
                        if (ModelState.IsValid)
                        {
                              _service.Update(new VehicleModel { Id = objToEdit.Id, Name = objToEdit.Name, MakeId = objToEdit.MakeId });
                              _context.SaveChanges();

                              return RedirectToAction("Index", new { id = objToEdit.MakeId });
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
                  return View(new VehicleModelVM { Id = objToDelete.Id, Name = objToDelete.Name, MakeId = objToDelete.MakeId });
            }

            [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int id)
            {
                  var objToDelete = _service.GetById(id);

                  try
                  {
                        _service.Delete(id);
                        _context.SaveChanges();

                        return RedirectToAction("Index", new { id = objToDelete.MakeId });
                  }
                  catch
                  {
                        return View();
                  }
            }

            #endregion
      }
}