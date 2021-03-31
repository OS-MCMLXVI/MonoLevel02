using Project.MVC.ViewModels;
using Project.Service;
using Project.Service.DAL;
using Project.Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Project.MVC.Controllers
{
      public class VehicleController : Controller
      {
            VehicleContext _context;
            VehicleService<VehicleMake> _makeService;
            VehicleService<VehicleModel> _modelService;


            public VehicleController()
            {
                  this._context = new VehicleContext();
                  this._makeService = new VehicleService<VehicleMake>(this._context);
                  this._modelService = new VehicleService<VehicleModel>(this._context);
            }


            #region VehicleMake
                        
            #region MakesList (Index)

            
            // GET: Make
            public ActionResult IndexMakes()
            {
                  List<VehicleMakeVM> vehicleMakeVMList = new List<VehicleMakeVM>();
                  var makeList = _makeService.GetAll();

                  foreach (var make in makeList)
                  {
                        vehicleMakeVMList.Add(
                              new VehicleMakeVM
                              {
                                    MakeId = make.Id,
                                    MakeName = make.Name
                              });
                  }

                  return View(vehicleMakeVMList);
            }
            
            
            #endregion

            #region CreateMake
            
            
            // GET: Make/Create
            public ActionResult CreateMake()
            {
                  return View(new VehicleMakeVM());
            }


            // POST: Make/Create
            [HttpPost]
            //public ActionResult Create(FormCollection collection)
            public ActionResult CreateMake(VehicleMakeVM objToCreate)
            {
                  try
                  {
                        if (ModelState.IsValid)
                        {
                              _makeService.Insert(new VehicleMake { Id = objToCreate.MakeId, Name = objToCreate.MakeName });
                              _context.SaveChanges();

                              return RedirectToAction("IndexMakes");
                        }

                        return View();
                  }
                  catch
                  {
                        return View();
                  }
            }
            
            
            #endregion

            #region EditMake
            
            
            // GET: Make/Edit/5
            public ActionResult EditMake(int makeId)
            {
                  var makeObj = _makeService.GetById(makeId);
                  return View(new VehicleMakeVM { MakeId = makeObj.Id, MakeName = makeObj.Name });
            }

            
            // POST: Make/Edit/5
            [HttpPost]
            public ActionResult EditMake(VehicleMakeVM makeVM)
            {
                  try
                  {
                        if (ModelState.IsValid)
                        {
                              _makeService.Update(new VehicleMake { Id = makeVM.MakeId, Name = makeVM.MakeName });
                              _context.SaveChanges();
                              return RedirectToAction("IndexMakes");
                        }

                        return View();
                  }
                  catch
                  {
                        return View();
                  }
            }


            #endregion

            #region DeleteMake


            // GET: Make/Delete/5
            public ActionResult DeleteMake(int makeId)
            {
                  var makeObj = _makeService.GetById(makeId);
                  return View(new VehicleMakeVM { MakeId = makeObj.Id, MakeName = makeObj.Name });
            }


            // POST: Make/Delete/5
            [HttpPost]
            public ActionResult DeleteMake(VehicleMakeVM makeVM)
            {
                  try
                  {
                        if (ModelState.IsValid)
                        {
                              _makeService.Delete(makeVM.MakeId);
                              _context.SaveChanges();
                              return RedirectToAction("IndexMakes");
                        }

                        return View();
                  }
                  catch
                  {
                        return View();
                  }
            }


            #endregion

            #endregion


            #region VehicleModel

            #region ModelsList (Index)


            // GET: Model
            public ActionResult IndexModels(int makeId)
            {
                  List<VehicleModelVM> vehicleModelVMList = new List<VehicleModelVM>();
                  var modelList = _modelService.GetAll();

                  foreach (var model in modelList.Where(x=>x.MakeId==makeId))
                  {
                        vehicleModelVMList.Add(
                              new VehicleModelVM
                              {
                                    ModelId = model.Id,
                                    ModelName = model.Name,
                                    MakeId = model.MakeId
                              });
                  }

                  ViewBag.ID = makeId;
                  return View(vehicleModelVMList);
            }


            #endregion

            #region CreateModel


            // GET: Vehicle/CreateModel
            public ActionResult CreateModel(int id)
            {
                  return View(new VehicleModelVM { MakeId = id });
            }


            // POST: Vehicle/CreateModel
            [HttpPost]
            public ActionResult CreateModel(VehicleModelVM objToCreate)
            {
                  try
                  {
                        if (ModelState.IsValid)
                        {
                              _modelService.Insert(new VehicleModel{ Id = objToCreate.ModelId, Name = objToCreate.ModelName, MakeId = objToCreate.MakeId });
                              _context.SaveChanges();

                              return RedirectToAction("IndexModels", "Vehicle", new { objToCreate.MakeId });
                        }

                        return View();
                  }
                  catch
                  {
                        return View();
                  }
            }


            #endregion

            #region EditMake


            // GET: Model/Edit/5
            public ActionResult EditModel(int modelId)
            {
                  var modelObj = _modelService.GetById(modelId);
                  return View(new VehicleModelVM { ModelId = modelObj.Id, ModelName = modelObj.Name, MakeId = modelObj.MakeId });
            }


            // POST: Make/Edit/5
            [HttpPost]
            public ActionResult EditModel(VehicleModelVM modelVM)
            {
                  try
                  {
                        if (ModelState.IsValid)
                        {
                              _modelService.Update(new VehicleModel{ Id = modelVM.ModelId, Name = modelVM.ModelName, MakeId = modelVM.MakeId  });
                              _context.SaveChanges();

                              return RedirectToAction("IndexModels", "Vehicle", new { modelVM.MakeId });
                        }

                        return View();
                  }
                  catch
                  {
                        return View();
                  }
            }


            #endregion

            #region DeleteModel


            // GET: Vehicle/DeleteModel/5
            public ActionResult DeleteModel(int modelId)
            {
                  var modelObj = _modelService.GetById(modelId);
                  return View(new VehicleModelVM { ModelId = modelObj.Id, ModelName = modelObj.Name, MakeId = modelObj.MakeId });
            }


            // POST: Vehicle/DeleteModel/5
            [HttpPost]
            public ActionResult DeleteModel(VehicleModelVM modelVM)
            {
                  try
                  {
                        if (ModelState.IsValid)
                        {
                              _modelService.Delete(modelVM.ModelId);
                              _context.SaveChanges();

                              return RedirectToAction("IndexModels", "Vehicle", new { modelVM.MakeId });
                        }

                        return View();
                  }
                  catch
                  {
                        return View();
                  }
            }


            #endregion

            #endregion
      }
}