using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcVehicleService4.Business.Interface
{
   public  interface IVehicleBusiness
    {

        // Vehicle Make
        List<VehicleMake> GetAllVehicleMakes();
        VehicleMake GetVehicleMakeByID(int vehicleMakeId); // R
        void InsertVehicleMake(VehicleMake vehicleMake); // C
        void DeleteVehicleMake(int vehicleMakeId); //D
        void UpdateVehicleMake(VehicleMake vehicleMake); //U

        // Vehicle Model
        List<VehicleModel> GetAllVehicleModels();
        VehicleModel GetVehicleModelByID(int vehicleModelId); // R
        void InsertVehicleModel(VehicleModel vehicleModel); // C
        void DeleteVehicleModel(int vehicleModelId); //D
        void UpdateVehicleModel(VehicleModel vehicleModel); //U
    }
}
  


