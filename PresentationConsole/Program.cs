using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                VehicleController controller = new VehicleController();

                //​​"Volvo", "Saab", "Honda" or "Suzuki".
                VehicleMake make = new VehicleMake();
                make.Description = "Volvo";

                VehicleMake make1 = new VehicleMake();
                make1.Description = "Saab";

                VehicleMake make2 = new VehicleMake();
                make2.Description = "Honda";

                VehicleMake make3 = new VehicleMake();
                make3.Description = "Suzuki";

                VehicleType type1 = new VehicleType();
                type1.Description = "Car";

                VehicleType type2 = new VehicleType();
                type2.Description = "Bike";

                Vehicle vehicle = new Vehicle();
                vehicle.Description = "My New Car";
                vehicle.RegistrationId = "ABC-134";
                vehicle.MakeId = 1;
                vehicle.TypeId = 1;

                Vehicle vehicle1 = new Vehicle();
                vehicle1.Description = "My Honda Bike";
                vehicle1.RegistrationId = "DEF-8853";
                vehicle1.MakeId = 3;
                vehicle1.TypeId = 2;



                controller.CreateOrUpdateVehicleMake(make);
                controller.CreateOrUpdateVehicleMake(make1);
                controller.CreateOrUpdateVehicleMake(make2);
                controller.CreateOrUpdateVehicleMake(make3);

                controller.CreateOrUpdateVehicleType(type1);
                controller.CreateOrUpdateVehicleType(type2);

                controller.CreateOrUpdateVehicle(vehicle);
                controller.CreateOrUpdateVehicle(vehicle1);

                Console.WriteLine("Information Saved Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:  "+ex.Message );
            }
            

        }
    }
}
