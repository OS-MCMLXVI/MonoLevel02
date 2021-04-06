using AutoMapper;
using Project.MVC.ViewModels;
using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVC.MappingProfiles
{
      public class MappingProfile : Profile
      {
            public MappingProfile()
            {
                  CreateMap<VehicleMake, VehicleMakeVM>()
                        .ForMember(dest => dest.MakeId, act => act.MapFrom(src => src.Id))
                        .ForMember(dest => dest.MakeName, act => act.MapFrom(src => src.Name));

                  CreateMap<VehicleMakeVM, VehicleMake>()
                        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.MakeId))
                        .ForMember(dest => dest.Name, act => act.MapFrom(src => src.MakeName));

            }
      }
}