using MvcVehicleService4.Business.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcVehicleService4.Business
{
      public class VehicleModelService : IVehicleModelService
    {
        VehicleBaseEntitiesConn dbContext = new VehicleBaseEntitiesConn();
 
        // Vehicle Model ===========
     
        public void DeleteVehicleModel(int vehicleModelId)
        {
           VehicleModel usermodel = dbContext.VehicleModels.Find(vehicleModelId);
           dbContext.VehicleModels.Remove(usermodel);
           dbContext.SaveChanges();
        }

        public VehicleModel GetVehicleModelByID(int vehicleModelId)
        {
           return dbContext.VehicleModels.Find(vehicleModelId);
        }

        public void InsertVehicleModel(VehicleModel vehicleModel)
        {
            dbContext.VehicleModels.Add(vehicleModel);
            dbContext.SaveChanges();
        }

        public void UpdateVehicleModel(VehicleModel vehicleModel)
        {
            dbContext.Entry(vehicleModel).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
             
       
        public IQueryable<VehicleModel> GetVehicleModel(string searchString)
        {
      
            int searchResult = 1;
            if (!String.IsNullOrEmpty(searchString))
            {
                searchResult = Int32.Parse(searchString);
            }
            var vehiclemodels = dbContext.VehicleModels.Where(s => s.MakeId == searchResult);
            return vehiclemodels;
        }
    }

}
