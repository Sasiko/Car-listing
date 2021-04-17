using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataLayer
{
    public class VehiclesContext : DbContext
    {
        public VehiclesContext() : base("VehiclesContext")
        {

        }

        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
