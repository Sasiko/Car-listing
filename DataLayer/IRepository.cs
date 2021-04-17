using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IRepository
    {

        IEnumerable<Vehicle> GetAllVehicles();
        IEnumerable<VehicleMake> GetAllVehicleMake();
        IEnumerable<VehicleType> GetAllVehicleType();

        void CreateOrUpdateVehicle(Vehicle vehicle);
        void CreateOrUpdateVehicleType(VehicleType vehicleType);
        void CreateOrUpdateVehicleMake(VehicleMake vehicleMake);
        void DeleteVehicle(int vehicleId);
        void DeleteVehicleType(int vehicleTypeId);
        void DeleteVehicleMake(int vehicleMakeId);

        void SaveChanges();
    }
}
