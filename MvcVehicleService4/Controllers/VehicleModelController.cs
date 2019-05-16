//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace MvcVehicleService4.Controllers
//{
//    public class VehicleModelController : Controller
//    {
//        // GET: VehicleModel
//        public ActionResult Index()
//        {
//            return View();
//        }
//    }
//}
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
        // GET: Vehicle
        //public ActionResult Index()
        //{
        //    return View();
        //}
        // GET: Vehicle

        VehicleBaseEntitiesConn _dbContext = new VehicleBaseEntitiesConn();
        IVehicleBusiness vehicleBusiness = new VehicleBusiness();
        //     public ActionResult Index()


        //     public ActionResult Index(string Sorting_Order,  string searchString)
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




            //var vehiclemakes = from vehiclemake in vehicleBusiness.GetAllVehicleMakes()
            //                  select vehiclemake;

            var vehiclemodels = from vehiclemodel in this._dbContext.VehicleModels
                                select vehiclemodel;

            // var employeeList = _db.Employees.ToList();


            if (!String.IsNullOrEmpty(searchString))
            {
                //   employees = employees.Where(s => s.LastName.Contains(searchString)|| s.FirstMidName.Contains(searchString));
                //    vehiclemodels = vehiclemodels.Where(s => s.MakeId.Contains(searchString));

                int searchResult = Int32.Parse(searchString);
                vehiclemodels = vehiclemodels.Where(s => s.MakeId == (searchResult));
              
            }
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

            //  return View(vehiclemakes.ToList());
            //   IVehicleBusiness vehicleBusiness = new VehicleBusiness();


            //  List<VehicleMake> listVMModel = vehicleBusiness.GetAllVehicleMakes();
            List<VehicleModel> listVMModel = vehiclemodels.ToList();
            List<VehicleModelViewModel> listVMModelViewMmodel = new List<VehicleModelViewModel>();
            //foreach ( var item in listDom)
            //{
            //    VehicleMake vm = new VehicleMake();
            //       vm.ID = item.ID;
            //    vm.Name = item.Name;
            //    vm.Abrv = item.Abrv;
            //    listviewmodel.Add(vm);
            // }

            AutoMapper.Mapper.Map(listVMModel, listVMModelViewMmodel);


            //   ViewBag.ListaVMView = listVMViewMmodel;
            //  return View(vehiclemakes.ToList());
            //   return View(listVMViewMmodel);

            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(listVMModelViewMmodel.ToPagedList(pageNumber, pageSize));
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
            var v_vehicleModel = vehicleBusiness.GetVehicleModelByID(id); // calling GetEmployeeByID method of EmployeeRepository
            return View(v_vehicleModel);
            //    return View();
        }
        [HttpPost]

        public ActionResult Delete(int id, VehicleModel vehicleModel)
        {
            //   IVehicleBusiness vehicleBusiness = new VehicleBusiness();
            try
            {
                vehicleBusiness.DeleteVehicleModel(id);
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
        public ActionResult Create(FormCollection collection, VehicleModel vehicleModel)
        {
            try
            {
                // TODO: Add insert logic here
                //    IVehicleBusiness vehicleBusiness = new VehicleBusiness();
                vehicleBusiness.InsertVehicleModel(vehicleModel);
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
            var v_vehicleModel = vehicleBusiness.GetVehicleModelByID(id);


            var vv_vehicleModel = new VehicleModel();

            vv_vehicleModel.ID = id;
            vv_vehicleModel.MakeId = v_vehicleModel.MakeId;
            vv_vehicleModel.Name = v_vehicleModel.Name;
            vv_vehicleModel.Abrv = v_vehicleModel.Abrv;
            return View(vv_vehicleModel);

            //    return View();
        }
        //
        // POST: /Emp/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection, VehicleModel vehicleModel)
        {
            try
            {
                // TODO: Add update logic here

                //   var v_vehicleMake = new VehicleMake();
                vehicleBusiness.UpdateVehicleModel(vehicleModel);
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
            var v_vehicleModel = vehicleBusiness.GetVehicleModelByID(id);


            var vv_vehicleModel = new VehicleModel();
            
            vv_vehicleModel.ID = id;
            vv_vehicleModel.MakeId = v_vehicleModel.MakeId;
            vv_vehicleModel.Name = v_vehicleModel.Name;
            vv_vehicleModel.Abrv = v_vehicleModel.Abrv;
            return View(vv_vehicleModel);


            //    return View();
        }


    }
}