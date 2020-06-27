using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // Create an instance of a car
    internal class Car : Vehicle
    {
        public enum eColorOfCar
        {
            Red,
            White,
            Black,
            Silver
        }

        private eColorOfCar m_Color;
        private int m_NumberOfDoors;

        internal Car(eColorOfCar i_Color, int i_Number, string i_ModelName, List<Wheel> i_WheelList, Engine i_Engine, float i_EnergyPercent, string i_LicenseNumber, Dictionary<string, string> i_VehicleInfo) :
            base(i_ModelName, i_WheelList, i_Engine, i_EnergyPercent, i_LicenseNumber, i_VehicleInfo)
        {
            this.m_Color = i_Color;
            this.m_NumberOfDoors = i_Number;
        }

        internal eColorOfCar Color
        {
            get
            {
                return this.m_Color;
            }

            set
            {
                this.m_Color = value;
            }
        }

        internal int NumberOfDoors
        {
            get
            {
                return this.m_NumberOfDoors;
            }

            set
            {
                if (value > 5 || value < 2)
                {
                    throw new ValueOutOfRangeException(2, 5);
                }

                this.m_NumberOfDoors = value;
            }
        }

        // Return a list of a specific info of a car
        internal static Dictionary<string, string> GeneralCarInfo()
        {
            StringBuilder colorsAvailable = new StringBuilder();
            colorsAvailable.Append("Choose one of the colors below:" + Environment.NewLine);
            foreach (eColorOfCar color in Enum.GetValues(typeof(eColorOfCar)))
            {
                colorsAvailable.Append(color.ToString() + Environment.NewLine);
            }

            Dictionary<string, string> carInfo = new Dictionary<string, string>() { { colorsAvailable.ToString(), string.Empty }, { "Number Of Doors", string.Empty } };
            return carInfo;
        }

        // Check extra data 
        internal static Dictionary<string, string> CheckExtraData(Dictionary<string, string> i_Parameteres)
        {
            string color = i_Parameteres.Values.ElementAt(0);
            if (!Validation.CheckIfEnum(color, new eColorOfCar()))
            {
                throw new ArgumentException("car color: Illegal argument");
            }

            string NumberOfDoors = i_Parameteres.Values.ElementAt(1);
            if ( !Validation.CheckMinMaxValidity(NumberOfDoors, 2, 5))
            {
                throw new FormatException("Number Of Doors: please enter a valid number");
            }

            Dictionary<string, string> resultsParameters = new Dictionary<string, string>();
            resultsParameters.Add("Color", i_Parameteres.Values.ElementAt(0));
            resultsParameters.Add("Number of doors", i_Parameteres.Values.ElementAt(1));
            return resultsParameters;
        }
    }
}
