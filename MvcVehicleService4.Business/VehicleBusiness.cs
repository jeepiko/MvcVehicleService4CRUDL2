using MvcVehicleService4.Business.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcVehicleService4.Business
{
    public class VehicleBusiness : IVehicleBusiness
    {

      //   private VehicleBaseEntitiesConn dbContext;

        //public VehicleBusiness(VehicleBaseEntitiesConn objempcontext)

        //{
        //    this.dbContext = objempcontext;
        //}
      
        VehicleBaseEntitiesConn dbContext = new VehicleBaseEntitiesConn();


        // Vehicle Make

        public List<VehicleMake> GetAllVehicleMakes()
        {

         //    VehicleBaseEntitiesConn dbContext = new VehicleBaseEntitiesConn();
         

             List<VehicleMake> list = dbContext.VehicleMakes.ToList();
       //    List<VehicleMake> list = dbContext.VehicleMakes.Select(m => new VehicleMake { ID = m.ID, Name = m.Name, Abrv = m.Abrv }).ToList();
            return list;
        }
        //public void DeleteVehicleMake(int VehicleId)
        //{
        //    VehicleBaseEntitiesConn dbContext = new VehicleBaseEntitiesConn();

        //    VehicleMake user = dbContext.VehicleMakes.Find(VehicleId);

        //    dbContext.VehicleMakes.Remove(user);

        //    dbContext.SaveChanges();
        //    //   throw new NotImplementedException();
        //}
        public void DeleteVehicleMake(int vehicleMakeId)

        {
          //  VehicleBaseEntitiesConn dbContext = new VehicleBaseEntitiesConn();

            VehicleMake user = dbContext.VehicleMakes.Find(vehicleMakeId);

            dbContext.VehicleMakes.Remove(user);

            dbContext.SaveChanges();

        }


        //public void Save()
        //{
        //    throw new NotImplementedException();
        //}

        public VehicleMake GetVehicleMakeByID(int vehicleMakeId)
        {
          //  VehicleBaseEntitiesConn dbContext = new VehicleBaseEntitiesConn();
            //  throw new NotImplementedException();
            return dbContext.VehicleMakes.Find(vehicleMakeId);
        }

        public void InsertVehicleMake(VehicleMake vehicleMake)
        {
        //    VehicleBaseEntitiesConn dbContext = new VehicleBaseEntitiesConn();
            dbContext.VehicleMakes.Add(vehicleMake);
            dbContext.SaveChanges();
          //   throw new NotImplementedException();
        }

        public void UpdateVehicleMake(VehicleMake vehicleMake)
        {
            dbContext.Entry(vehicleMake).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        // Vehicle Model ===========

                public List<VehicleModel> GetAllVehicleModels()
        {

            //    VehicleBaseEntitiesConn dbContext = new VehicleBaseEntitiesConn();


            List<VehicleModel> list = dbContext.VehicleModels.ToList();
            //    List<VehicleMake> list = dbContext.VehicleMakes.Select(m => new VehicleMake { ID = m.ID, Name = m.Name, Abrv = m.Abrv }).ToList();
            return list;
        }
        //public void DeleteVehicleMake(int VehicleId)
        //{
        //    VehicleBaseEntitiesConn dbContext = new VehicleBaseEntitiesConn();

        //    VehicleMake user = dbContext.VehicleMakes.Find(VehicleId);

        //    dbContext.VehicleMakes.Remove(user);

        //    dbContext.SaveChanges();
        //    //   throw new NotImplementedException();
        //}
        public void DeleteVehicleModel(int vehicleModelId)

        {
            //  VehicleBaseEntitiesConn dbContext = new VehicleBaseEntitiesConn();

            VehicleModel usermodel = dbContext.VehicleModels.Find(vehicleModelId);

            dbContext.VehicleModels.Remove(usermodel);

            dbContext.SaveChanges();

        }


        //public void Save()
        //{
        //    throw new NotImplementedException();
        //}

        public VehicleModel GetVehicleModelByID(int vehicleModelId)
        {
            //  VehicleBaseEntitiesConn dbContext = new VehicleBaseEntitiesConn();
            //  throw new NotImplementedException();
            return dbContext.VehicleModels.Find(vehicleModelId);
        }

        public void InsertVehicleModel(VehicleModel vehicleModel)
        {
            //    VehicleBaseEntitiesConn dbContext = new VehicleBaseEntitiesConn();
            dbContext.VehicleModels.Add(vehicleModel);
            dbContext.SaveChanges();
            //   throw new NotImplementedException();
        }

        public void UpdateVehicleModel(VehicleModel vehicleModel)
        {
            dbContext.Entry(vehicleModel).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

    }







}
