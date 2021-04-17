using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Repository : IRepository
    {
        private VehiclesContext dbContext;

        public Repository(VehiclesContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void CreateOrUpdateVehicle(Vehicle vehicle)
        {
            if (vehicle.Id > 0)
            {
                var _vehicle = dbContext.Vehicles.FirstOrDefault(x => x.Id == vehicle.Id);
                if (_vehicle != null)
                {
                    _vehicle.Description = vehicle.Description;
                    _vehicle.RegistrationId = vehicle.RegistrationId;

                }
            }
            else
            {
                dbContext.Vehicles.Add(vehicle);
            }
        }

        public void CreateOrUpdateVehicleMake(VehicleMake vehicleMake)
        {
            if (vehicleMake.MakeId > 0)
            {
                var _vehicle = dbContext.VehicleMakes.FirstOrDefault(x => x.MakeId == vehicleMake.MakeId);
                if (_vehicle != null)
                {
                    _vehicle.Description = vehicleMake.Description;
                }
            }
            else
            {
                dbContext.VehicleMakes.Add(vehicleMake);
            }
        }

        public void CreateOrUpdateVehicleType(VehicleType vehicleType)
        {
            if (vehicleType.TypeId > 0)
            {
                var _vehicle = dbContext.VehicleTypes.FirstOrDefault(x => x.TypeId == vehicleType.TypeId);
                if (_vehicle != null)
                {
                    _vehicle.Description = vehicleType.Description;
                }
            }
            else
            {
                dbContext.VehicleTypes.Add(vehicleType);
            }
        }

        public void DeleteVehicle(int vehicleId)
        {
            var vehicle = dbContext.Vehicles.First(x => x.Id == vehicleId);
            dbContext.Vehicles.Remove(vehicle);
        }

        public void DeleteVehicleMake(int vehicleMakeId)
        {
            var vehicle = dbContext.VehicleMakes.First(x => x.MakeId == vehicleMakeId);
            dbContext.VehicleMakes.Remove(vehicle);
        }

        public void DeleteVehicleType(int vehicleTypeId)
        {
            var vehicle = dbContext.VehicleTypes.First(x => x.TypeId == vehicleTypeId);
            dbContext.VehicleTypes.Remove(vehicle);
            dbContext.SaveChanges();
        }

        public IEnumerable<VehicleMake> GetAllVehicleMake()
        {
            return dbContext.VehicleMakes.ToList();
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return dbContext.Vehicles.ToList();
        }

        public IEnumerable<VehicleType> GetAllVehicleType()
        {
            return dbContext.VehicleTypes.ToList();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
