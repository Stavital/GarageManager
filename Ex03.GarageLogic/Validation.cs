using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.VehicleCreation;

namespace Ex03.GarageLogic
{
    public class Validation
    {
        // Check if the vehicle support by the garage
        public static bool TypeOfVehicle(string i_VehicleType)
        {
            eVehicleType tryToParse;
            int numberOfVehicleType = Enum.GetValues(typeof(eVehicleType)).Length;

            bool isInt = int.TryParse(i_VehicleType, out int chosenNumber);
            if (!isInt)
            {
                throw new FormatException("Please enter a number");
            }

            if(chosenNumber < 0 || chosenNumber > numberOfVehicleType)
            {
                throw new ArgumentException("Please choose a valid option");
            }

            bool vehicleType = Enum.TryParse<eVehicleType>(i_VehicleType, out tryToParse);
            if (!vehicleType)
            {
                throw new ArgumentException("This vehicle is not supported by our garage.");
            }

            return true;
        }

        internal static bool CheckIfANumber(string i_Input)
        {
             return float.TryParse(i_Input, out float input);
        }

        // check if an input is between min and max
        internal static bool CheckMinMaxValidity(string i_UserPick, int i_Min, int i_Max)
        {
            bool isVaild = true; 
            int userIntegerPick = 0;
            bool isInt = int.TryParse(i_UserPick, out userIntegerPick);
            if (!isInt)
            {
                isVaild = false;
            }

            if (userIntegerPick < i_Min || userIntegerPick > i_Max)
            {
                isVaild = false;
            }

            return isVaild;
        }

        // check if an input is one of the types of an enum
        internal static bool CheckIfEnum(string i_Input, Enum i_Property)
        {
            bool isVaild = false;
            foreach (string property in Enum.GetNames(i_Property.GetType()))
            {
                if(property == i_Input)
                {
                    isVaild = true;
                }
            }

            return isVaild;
        }
    }
}
