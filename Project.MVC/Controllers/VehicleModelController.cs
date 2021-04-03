﻿using Project.MVC.ViewModels;
using Project.Service;
using Project.Service.DAL;
using Project.Service.Models;
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

            public ActionResult Index(int id)
            {
                  List<VehicleModelVM> viewList = new List<VehicleModelVM>();
                  var sourceList = _service.GetAll().Where(x => x.MakeId == id);

                  foreach (var model in sourceList)
                  {
                        viewList.Add(new VehicleModelVM
                        {
                              ModelId = model.Id,
                              ModelName = model.Name,
                              MakeId = model.MakeId
                        });
                  }

                  ViewBag.ID = id;
                  return View(viewList);
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
                              _service.Insert(new VehicleModel { Name = objToCreate.ModelName, MakeId = objToCreate.MakeId });
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
                  return View(new VehicleModelVM { ModelId = objToView.Id, ModelName = objToView.Name, MakeId = objToView.MakeId });
            }

            #endregion

            
            #region Edit

            public ActionResult Edit(int id)
            {
                  var objToEdit = _service.GetById(id);
                  return View(new VehicleModelVM { ModelId = objToEdit.Id, ModelName = objToEdit.Name, MakeId = objToEdit.MakeId });
            }

            [HttpPost]
            public ActionResult Edit(VehicleModelVM objToEdit)
            {
                  try
                  {
                        if (ModelState.IsValid)
                        {
                              _service.Update(new VehicleModel { Id = objToEdit.ModelId, Name = objToEdit.ModelName, MakeId = objToEdit.MakeId });
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
                  return View(new VehicleModelVM { ModelId = objToDelete.Id, ModelName = objToDelete.Name, MakeId = objToDelete.MakeId });
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