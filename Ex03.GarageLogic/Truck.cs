using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // Create an instance of a truck
    public class Truck : Vehicle
    {
        private bool m_IsDangerous;
        private float m_CargoVolume;

        public Truck(bool i_IsDangerous, float i_CargoVolume, string i_ModelName, List<Wheel> i_WheelList, Engine i_Engine, float i_EnergyPercent, string i_LicenseNumber, Dictionary<string, string> i_VehicleInfo) : base(i_ModelName, i_WheelList, i_Engine, i_EnergyPercent, i_LicenseNumber, i_VehicleInfo)
        {
            this.m_IsDangerous = i_IsDangerous;
            this.m_CargoVolume = i_CargoVolume;
        }

        public bool IsDangerous
        {
            get
            {
                return this.m_IsDangerous;
            }

            set
            {
                this.m_IsDangerous = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return this.m_CargoVolume;
            }

            set
            {
                this.m_CargoVolume = value;
            }
        }

        // Return a list of a specific info of a truck
        public static Dictionary<string, string> GeneralTruckInfo()
        {
            Dictionary<string, string> truckInfo = new Dictionary<string, string>();
            string dangerousMaterials = string.Empty;
            string cargoVolume = string.Empty;
            truckInfo.Add("Dangerous Materials, enter 1 for yes, 2 for no", dangerousMaterials);
            truckInfo.Add("Cargo Volume, enter a number", cargoVolume);

            return truckInfo;
        }

        // Check extra data 
        public static Dictionary<string, string> CheckExtraData(Dictionary<string, string> i_Parameteres)
        {
            string isDangerous = i_Parameteres.Values.ElementAt(0);
            if (!Validation.CheckIfANumber(isDangerous))
            {
                throw new FormatException("Dangerous Materials: please enter a number");
            }

            if(isDangerous != "1" && isDangerous != "2")
            {
                throw new ArgumentException("Dangerous Materials: Illegal number");
            }

            string cargoVolume = i_Parameteres.Values.ElementAt(1);
            if (!Validation.CheckIfANumber(cargoVolume))
            {
                throw new FormatException("Cargo Volume: please enter a number");
            }

            Dictionary<string, string> resultsParameters = new Dictionary<string, string>();
            resultsParameters.Add("Dangerous Materials", i_Parameteres.Values.ElementAt(0));
            resultsParameters.Add("Cargo Volume", i_Parameteres.Values.ElementAt(1));
            return resultsParameters;
        }
    }
}
