using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Entities;

namespace BusinessLayer
{
    public class VehicleController
    {
        UnitOfWork Unit = new UnitOfWork(new VehiclesContext());

        public void CreateOrUpdateVehicle(Vehicle vehicle)
        {
            Unit.Repo.CreateOrUpdateVehicle(vehicle);
            Unit.Save();
        }

        public void CreateOrUpdateVehicleMake(VehicleMake vehicleMake)
        {
            Unit.Repo.CreateOrUpdateVehicleMake(vehicleMake);
            Unit.Save();
        }

        public void CreateOrUpdateVehicleType(VehicleType vehicleType)
        {
            Unit.Repo.CreateOrUpdateVehicleType(vehicleType);
            Unit.Save();
        }

        public void DeleteVehicle(int vehicleId)
        {
            Unit.Repo.DeleteVehicle(vehicleId);
            Unit.Save();
        }

        public void DeleteVehicleMake(int vehicleMakeId)
        {
            Unit.Repo.DeleteVehicleMake(vehicleMakeId);
            Unit.Save();
        }

        public void DeleteVehicleType(int vehicleTypeId)
        {
            Unit.Repo.DeleteVehicleType(vehicleTypeId);
            Unit.Save();
        }

        public IEnumerable<VehicleMake> GetAllVehicleMake()
        {
            return Unit.Repo.GetAllVehicleMake();
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return Unit.Repo.GetAllVehicles();
        }

        public IEnumerable<VehicleType> GetAllVehicleType()
        {
            return Unit.Repo.GetAllVehicleType();
        }
    }
}
