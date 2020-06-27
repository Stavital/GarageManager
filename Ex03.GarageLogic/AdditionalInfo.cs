using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // Create a list of an aditinal info of a specific vehicle
    public class AdditionalInfo
    {
        // return a dict of the aditinal info of a vehicle 
        public static Dictionary<string, string> AditionalInfo(VehicleCreation.eVehicleType i_VehicleType)
        {
            Dictionary<string, string> aditionalInfo = null;

            if (i_VehicleType == VehicleCreation.eVehicleType.Car)
            {
                aditionalInfo = Car.GeneralCarInfo();
            }

            if (i_VehicleType == VehicleCreation.eVehicleType.Motorcycle)
            {
                aditionalInfo = Motorcycle.GeneralMotorcycleInfo();
            }

            if (i_VehicleType == VehicleCreation.eVehicleType.Truck)
            {
                aditionalInfo = Truck.GeneralTruckInfo();
            }

            return aditionalInfo;
        }
    }
}
