using Project.Service.Models.Interface;
using System;

namespace Project.Service.Models
{
      public class VehicleModel : IBaseModel
      {
            public int Id { get; set; }
            public string Name { get; set; }
            public int MakeId { get; set; }
            public virtual VehicleMake Make { get; set; }
      }
}