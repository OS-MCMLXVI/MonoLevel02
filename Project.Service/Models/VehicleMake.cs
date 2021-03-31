using Project.Service.Models.Interface;
using System.Collections.Generic;

namespace Project.Service.Models
{
      public class VehicleMake : IBaseModel
      {
            public int Id { get; set; }
            public string Name { get; set; }

            public virtual IEnumerable<VehicleModel> Models { get; set; }
      }
}