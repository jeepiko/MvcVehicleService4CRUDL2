using MvcVehicleService4.Business;
using MvcVehicleService4.Business.Interface;
using MvcVehicleService4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MvcVehicleService4.Controllers
{
    public class VehicleModelController : Controller
    {
             
        IVehicleModelService vehicleModelService = new VehicleModelService();
      
        public ActionResult Index(string Sorting_Order, string currentFilter, string searchString, int? page)
        {

               ViewBag.CurrentSort = Sorting_Order;
            ViewBag.SortingVehicleModelName = String.IsNullOrEmpty(Sorting_Order) ? "vehiclemodelname_desc" : "";
            ViewBag.SortingVehicleModelID = Sorting_Order == "vehiclemodelid" ? "vehiclemodelid_desc" : "vehiclemodelid";
            ViewBag.SortingVehicleModelMakeId = Sorting_Order == "vehiclemodelmakeid" ? "vehiclemodelmakeid_desc" : "vehiclemodelmakeid";
            ViewBag.SortingVehicleModelAbrv = Sorting_Order == "vehicleabrv" ? "vehicleabrv_desc" : "vehicleabrv";
           
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
          
             var vehiclemodels = vehicleModelService.GetVehicleModel(searchString);
        
            switch (Sorting_Order)
            {
                case "vehicleabrv_desc":
                    vehiclemodels = vehiclemodels.OrderByDescending(vehiclemodel => vehiclemodel.Abrv);
                    break;
                case "vehicleabrv":
                    vehiclemodels = vehiclemodels.OrderBy(vehiclemodel => vehiclemodel.Abrv);
                    break;
                case "vehiclemodelid_desc":
                    vehiclemodels = vehiclemodels.OrderByDescending(vehiclemodel => vehiclemodel.ID);
                    break;
                case "vehiclemodelid":
                    vehiclemodels = vehiclemodels.OrderBy(vehiclemodel => vehiclemodel.ID);
                    break;
                case "vehiclemodelmakeid_desc":
                    vehiclemodels = vehiclemodels.OrderByDescending(vehiclemodel => vehiclemodel.MakeId);
                    break;
                case "vehiclemodelmakeid":
                    vehiclemodels = vehiclemodels.OrderBy(vehiclemodel => vehiclemodel.MakeId);
                    break;
                case "vehiclemodelname_desc":
                    vehiclemodels = vehiclemodels.OrderByDescending(vehiclemodel => vehiclemodel.Name);
                    break;
                default:
                    vehiclemodels = vehiclemodels.OrderBy(vehiclemodel => vehiclemodel.Name);
                    break;
            }

            List<VehicleModel> listVMModel = vehiclemodels.ToList();
            List<VehicleModelViewModel> listVMModelViewMmodel = new List<VehicleModelViewModel>();

            AutoMapper.Mapper.Map(listVMModel, listVMModelViewMmodel);

            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(listVMModelViewMmodel.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Delete(int id)
        {
          var v_vehicleModel = vehicleModelService.GetVehicleModelByID(id);
          var vv_vehicleModel = new VehicleModelViewModel();
            AutoMapper.Mapper.Map(v_vehicleModel,vv_vehicleModel);
            return View(vv_vehicleModel);
         }
        [HttpPost]
        public ActionResult Delete(int id, VehicleModel vehicleModel)
        {
          //   id = 150;
          try
            {
                vehicleModelService.DeleteVehicleModel(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "the data has not been deleted");
               //  return View();
            }
        }

        // GET: /Emp/Create
        public ActionResult Create()
        {
            return View();
        }
        //
        // POST: /Emp/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, VehicleModel vehicleModel)
        {
           //  vehicleModel = null;
            try
            {
                vehicleModelService.InsertVehicleModel(vehicleModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "the data has not been created");
              //   return View();
            }
        }

        // GET: /Emp/Edit/5
        public ActionResult Edit(int id)
        {
            var v_vehicleModel = vehicleModelService.GetVehicleModelByID(id);
            var vv_vehicleModel = new VehicleModelViewModel();
            AutoMapper.Mapper.Map(v_vehicleModel, vv_vehicleModel);
            return View(vv_vehicleModel);
         }
        //
        // POST: /Emp/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection, VehicleModel vehicleModel)
        {
           //   vehicleModel.ID = 150;
            try
            {
               vehicleModelService.UpdateVehicleModel(vehicleModel);

             //    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return RedirectToAction("Index");
              
            }
            catch
            {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "the data has not been changed");
               //  return View();
             }
        }
        // GET: /Emp/Edit/5
        public ActionResult Details(int id)
        {
            var v_vehicleModel = vehicleModelService.GetVehicleModelByID(id);
            var vv_vehicleModel = new VehicleModelViewModel();
            AutoMapper.Mapper.Map(v_vehicleModel, vv_vehicleModel);
            return View(vv_vehicleModel);
        }


    }
}