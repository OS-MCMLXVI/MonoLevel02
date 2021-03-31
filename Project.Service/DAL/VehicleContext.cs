using Project.Service.Models;
using System.Data.Entity;

namespace Project.Service.DAL
{
      public class VehicleContext : DbContext
      {
            public VehicleContext() : base("VehicleDB")
            {
                  //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<VehicleContext>());
                  //Database.SetInitializer(new DropCreateDatabaseAlways<VehicleContext>());
                  //Database.SetInitializer(new VehicleInitializer());

                  

            }

            public DbSet<VehicleMake> VehicleMakes { get; set; }
            public DbSet<VehicleModel> VehicleModels { get; set; }
      }
}