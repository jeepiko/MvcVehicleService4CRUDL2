using MvcVehicleService4.Business.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace MvcVehicleService4.Business
{
    public class VehicleMakeService : IVehicleMakeService
    {
        VehicleBaseEntitiesConn dbContext = new VehicleBaseEntitiesConn();

        // Vehicle Make
           public void DeleteVehicleMake(int vehicleMakeId)
        {
          VehicleMake user = dbContext.VehicleMakes.Find(vehicleMakeId);
            dbContext.VehicleMakes.Remove(user);
            dbContext.SaveChanges();
        }
                
        public VehicleMake GetVehicleMakeByID(int vehicleMakeId)
        {
           return dbContext.VehicleMakes.Find(vehicleMakeId);
        }

        public void InsertVehicleMake(VehicleMake vehicleMake)
        {
            dbContext.VehicleMakes.Add(vehicleMake);
            dbContext.SaveChanges();
           
        }

        public void UpdateVehicleMake(VehicleMake vehicleMake)
        {
            dbContext.Entry(vehicleMake).State = EntityState.Modified;
            dbContext.SaveChanges();
        }


        public IQueryable<VehicleMake> GetVehicleMakes()
        { 
            var vehiclemakes = dbContext.VehicleMakes;
            return vehiclemakes;
        }

    }

}
