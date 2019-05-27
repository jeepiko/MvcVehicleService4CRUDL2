using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcVehicleService4.Business.Interface
{
    public interface IVehicleModelService
    {
        // Vehicle Model
        VehicleModel GetVehicleModelByID(int vehicleModelId); // R
        void InsertVehicleModel(VehicleModel vehicleModel); // C
        void DeleteVehicleModel(int vehicleModelId); //D
        void UpdateVehicleModel(VehicleModel vehicleModel); //U
        IQueryable<VehicleModel> GetVehicleModel(string searchString);
   }
}
