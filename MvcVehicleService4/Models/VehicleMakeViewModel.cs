using MvcVehicleService4.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcVehicleService4.Models
{
    public class VehicleMakeViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}