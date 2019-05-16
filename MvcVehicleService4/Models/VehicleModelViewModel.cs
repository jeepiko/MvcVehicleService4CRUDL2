using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcVehicleService4.Models
{
    public class VehicleModelViewModel
    {
        public int ID { get; set; }
        public Nullable<int> MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}