using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcVehicleService4.Business.Interface
{
    public interface IVehicleMakeService
    {
        // Vehicle Make
    
        VehicleMake GetVehicleMakeByID(int vehicleMakeId); // R
        void InsertVehicleMake(VehicleMake vehicleMake); // C
        void DeleteVehicleMake(int vehicleMakeId); //D
        void UpdateVehicleMake(VehicleMake vehicleMake); //U
        IQueryable<VehicleMake> GetVehicleMakes();
    }
}
