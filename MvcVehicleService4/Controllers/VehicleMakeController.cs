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
    public class VehicleMakeController : Controller
    {
       
        IVehicleMakeService vehicleMakeService = new VehicleMakeService();
    
              public ActionResult Index(string Sorting_Order, int? page)
        {

            ViewBag.SortingVehicleMakeName = String.IsNullOrEmpty(Sorting_Order) ? "vehiclename_desc" : "";
            ViewBag.SortingVehicleMakeID = Sorting_Order == "vehicleid" ? "vehicleid_desc" : "vehicleid";
            ViewBag.SortingVehicleMakeAbrv = Sorting_Order == "vehicleabrv" ? "vehicleabrv_desc" : "vehicleabrv";
      

            var vehiclemakes = vehicleMakeService.GetVehicleMakes();
          
            switch (Sorting_Order)
            {
               case "vehicleabrv_desc":
                    vehiclemakes = vehiclemakes.OrderByDescending(vehiclemake => vehiclemake.Abrv);
                    break;
                case "vehicleabrv":
                    vehiclemakes = vehiclemakes.OrderBy(vehiclemake => vehiclemake.Abrv);
                    break;
                case "vehicleid_desc":
                    vehiclemakes = vehiclemakes.OrderByDescending(vehiclemake => vehiclemake.ID);
                    break;
                case "vehicleid":
                    vehiclemakes = vehiclemakes.OrderBy(vehiclemake => vehiclemake.ID);
                    break;
                case "vehiclename_desc":
                    vehiclemakes = vehiclemakes.OrderByDescending(vehiclemake => vehiclemake.Name);
                    break;
                default:
                    vehiclemakes = vehiclemakes.OrderBy(vehiclemake => vehiclemake.Name );
                    break;
            }
       
            List<VehicleMake> listVMakeModel = vehiclemakes.ToList();
            List<VehicleMakeViewModel> listVMakeViewMmodel = new List<VehicleMakeViewModel>();
           

            AutoMapper.Mapper.Map(listVMakeModel,listVMakeViewMmodel);

                 int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(listVMakeViewMmodel.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Delete(int id)
        {
            var v_vehicleMake = vehicleMakeService.GetVehicleMakeByID(id);
            var vv_vehicleMake = new VehicleMakeViewModel();
           
            AutoMapper.Mapper.Map(v_vehicleMake,vv_vehicleMake);
            return View(vv_vehicleMake);
         }
        [HttpPost]
          public ActionResult Delete(int id, VehicleMake vehicleMake)
        {
           //  id = 150;
          try
            {
                vehicleMakeService.DeleteVehicleMake(id);
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
        public ActionResult Create(FormCollection collection, VehicleMake vehicleMake)
        {
          //  vehicleMake = null;
            try
            {
                vehicleMakeService.InsertVehicleMake(vehicleMake);
                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "the data has not been created");
               //  return View();
            }
        }

        // GET: /Emp/Edit/5
          public ActionResult Edit(int id)
        {
            var v_vehicleMake = vehicleMakeService.GetVehicleMakeByID(id);
            var vv_vehicleMake = new VehicleMakeViewModel();
            AutoMapper.Mapper.Map(v_vehicleMake,vv_vehicleMake);
           return View(vv_vehicleMake);
           }
       
        // POST: /Emp/Edit/5
         [HttpPost]
        public ActionResult Edit(FormCollection collection, VehicleMake vehicleMake)
        {
           //  vehicleMake.ID = 150;

            try
            {
                vehicleMakeService.UpdateVehicleMake(vehicleMake);
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
            var v_vehicleMake = vehicleMakeService.GetVehicleMakeByID(id);
            var vv_vehicleMake = new VehicleMakeViewModel();
            AutoMapper.Mapper.Map(v_vehicleMake,vv_vehicleMake);
           return View(vv_vehicleMake);
        }


    }
}