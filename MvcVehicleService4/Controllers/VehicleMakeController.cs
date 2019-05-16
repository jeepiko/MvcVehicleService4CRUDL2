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
        // GET: Vehicle
        //public ActionResult Index()
        //{
        //    return View();
        //}
        // GET: Vehicle

        VehicleBaseEntitiesConn _dbContext = new VehicleBaseEntitiesConn();
        IVehicleBusiness vehicleBusiness = new VehicleBusiness();
        //     public ActionResult Index()

       
           //      public ActionResult Index(string Sorting_Order,  string searchString)
              public ActionResult Index(string Sorting_Order, string searchString, int? page)
        {

         //    ViewBag.CurrentSort = Sorting_Order;
            ViewBag.SortingVehicleMakeName = String.IsNullOrEmpty(Sorting_Order) ? "vehiclename_desc" : "";
            ViewBag.SortingVehicleMakeID = Sorting_Order == "vehicleid" ? "vehicleid_desc" : "vehicleid";
            ViewBag.SortingVehicleMakeAbrv = Sorting_Order == "vehicleabrv" ? "vehicleabrv_desc" : "vehicleabrv";

           





            //var vehiclemakes = from vehiclemake in vehicleBusiness.GetAllVehicleMakes()
            //                  select vehiclemake;

            var vehiclemakes = from vehiclemake in this._dbContext.VehicleMakes
                               select vehiclemake;

            // var employeeList = _db.Employees.ToList();


            if (!String.IsNullOrEmpty(searchString))
            {
                //   employees = employees.Where(s => s.LastName.Contains(searchString)|| s.FirstMidName.Contains(searchString));
                vehiclemakes = vehiclemakes.Where(s => s.Name.Contains(searchString));
            }
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

            //  return View(vehiclemakes.ToList());
            //   IVehicleBusiness vehicleBusiness = new VehicleBusiness();


            //  List<VehicleMake> listVMModel = vehicleBusiness.GetAllVehicleMakes();
            List<VehicleMake> listVMakeModel = vehiclemakes.ToList();
            List<VehicleMakeViewModel> listVMakeViewMmodel = new List<VehicleMakeViewModel>();
            //foreach ( var item in listDom)
            //{
            //    VehicleMake vm = new VehicleMake();
            //       vm.ID = item.ID;
            //    vm.Name = item.Name;
            //    vm.Abrv = item.Abrv;
            //    listviewmodel.Add(vm);
            // }

            AutoMapper.Mapper.Map(listVMakeModel,listVMakeViewMmodel);


            //   ViewBag.ListaVMView = listVMViewMmodel;
           //  return View(vehiclemakes.ToList());
          //   return View(listVMViewMmodel);

                 int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(listVMakeViewMmodel.ToPagedList(pageNumber, pageSize));
        }
        //public ActionResult Delete(int id)
        //{
        //    IVehicleBusiness vehicleBusiness = new VehicleBusiness();
        //    // id = 7;
        //    vehicleBusiness.DeleteVehicleMake(id);
        //    return RedirectToAction("Index");
        //   //  return View();

        //}
        public ActionResult Delete(int id)

        {
            //   var objemp = Iemp.GetEmployeeByID(id); // calling GetEmployeeByID method of EmployeeRepository
        //     IVehicleBusiness vehicleBusiness = new VehicleBusiness();
            var v_vehicleMake = vehicleBusiness.GetVehicleMakeByID(id); 
            return View(v_vehicleMake);
         //    return View();
        }
        [HttpPost]

        public ActionResult Delete(int id, VehicleMake vehicleMake)
        {
          //   IVehicleBusiness vehicleBusiness = new VehicleBusiness();
            try
            {
                vehicleBusiness.DeleteVehicleMake(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
            try
            {
                // TODO: Add insert logic here
             //    IVehicleBusiness vehicleBusiness = new VehicleBusiness();
                vehicleBusiness.InsertVehicleMake(vehicleMake);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Emp/Edit/5
          public ActionResult Edit(int id)
        {
            var v_vehicleMake = vehicleBusiness.GetVehicleMakeByID(id);
            

            var vv_vehicleMake = new VehicleMake();

            vv_vehicleMake.ID = id;
            vv_vehicleMake.Name = v_vehicleMake.Name;
            vv_vehicleMake.Abrv = v_vehicleMake.Abrv;
                 return View(vv_vehicleMake);

         //    return View();
        }
          //
        // POST: /Emp/Edit/5
         [HttpPost]
        public ActionResult Edit(FormCollection collection, VehicleMake vehicleMake)
        {
            try
            {
                // TODO: Add update logic here

             //   var v_vehicleMake = new VehicleMake();
                vehicleBusiness.UpdateVehicleMake(vehicleMake);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Emp/Edit/5
        public ActionResult Details(int id)
        {
            var v_vehicleMake = vehicleBusiness.GetVehicleMakeByID(id);


            var vv_vehicleMake = new VehicleMake();

            vv_vehicleMake.ID = id;
            vv_vehicleMake.Name = v_vehicleMake.Name;
            vv_vehicleMake.Abrv = v_vehicleMake.Abrv;
            return View(vv_vehicleMake);

            //    return View();
        }


    }
}