using Project.MVC.ViewModels;
using Project.Service;
using Project.Service.DAL;
using Project.Service.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using System;
using System.Linq;
using AutoMapper;

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

            public ActionResult Index(string sortOrder, string currentSortOrder, int? page)
            {
                  //var mapperConfig = new MapperConfiguration(cfg => {
                  //      cfg.CreateMap<VehicleMake, VehicleMakeVM>()
                  //      .ForMember(dest => dest.MakeId, act => act.MapFrom(src => src.Id))
                  //      .ForMember(dest => dest.MakeName, act => act.MapFrom(src => src.Name)); });

                  //var mapiranje = new Mapper(mapperConfig);
                  //var sourceList =  _service.GetAll();
                  //var viewList = new List<VehicleMakeVM>();

                  //foreach (var make in sourceList)
                  //      viewList.Add(mapiranje.Map<VehicleMakeVM>(make));


                  //viewList = viewList.OrderBy(s => s.Name);
                  //ViewBag.SortOrder = String.IsNullOrEmpty(sortOrder) ? "descend" : "";

                  //if (currentSortOrder != sortOrder)
                  //{
                  //      ViewBag.CurrentSortOrder = sortOrder;

                  //      if (sortOrder == "descend")
                  //            viewList = viewList.OrderByDescending(s => s.Name);
                  //}

                  
                  //int pageSize = 5;
                  //int pageNumber = (page ?? 1);


                  //return View(viewList.ToPagedList(pageNumber, pageSize));




                  
                  
                  
                  
                  
                  
                  
                  
                  
                  
                  
                  
                  
                  
                  
                  
                  var sourceList = _service.GetAll().OrderBy(s => s.Name);
                  ViewBag.SortOrder = String.IsNullOrEmpty(sortOrder) ? "descend" : "";

                  if (currentSortOrder != sortOrder)
                  {
                        ViewBag.CurrentSortOrder = sortOrder;

                        if (sortOrder == "descend")
                              sourceList = sourceList.OrderByDescending(s => s.Name);
                  }


                  List<VehicleMakeVM> viewList = new List<VehicleMakeVM>();
                  foreach (var make in sourceList)
                        viewList.Add(new VehicleMakeVM { MakeId = make.Id, MakeName = make.Name });


                  int pageSize = 5;
                  int pageNumber = (page ?? 1);
                  return View(viewList.ToPagedList(pageNumber, pageSize));
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