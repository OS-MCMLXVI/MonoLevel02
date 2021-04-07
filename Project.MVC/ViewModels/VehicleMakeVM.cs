using Project.Service.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.MVC.ViewModels
{
      public class VehicleMakeVM
      {
            public int Id { get; set; }
            public string Name { get; set; }
      }
}