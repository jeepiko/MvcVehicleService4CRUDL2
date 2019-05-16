using MvcVehicleService4.Business;
using MvcVehicleService4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcVehicleService4.Infrastucture
{
    public class MyAutoMapperProfile : AutoMapper.Profile
    {
        


        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a => {
                a.AddProfile<MyAutoMapperProfile>();
            });
        }



        public MyAutoMapperProfile()
        {
            CreateMap<VehicleMake, VehicleMakeViewModel>();
            //Reverse
            CreateMap<VehicleMakeViewModel, VehicleMake>();


            CreateMap<VehicleModel, VehicleModelViewModel>();
            //Reverse
            CreateMap<VehicleModelViewModel, VehicleModel>();
        }
        //public MyAutoMapperProfile() { 
        //     CreateMap<VehicleMake, VehicleMakeViewModel>()
        //        .ForMember(dest=>dest.Name,opt=>opt.MapFrom(src=>src.Name.TrimEnd()))
        //        .ForMember(dest => dest.CurrentDate, opt => opt.MapFrom(src => src.CurrentDate.ToString("MM/dd/yyy hh")));
        //}
    }
}