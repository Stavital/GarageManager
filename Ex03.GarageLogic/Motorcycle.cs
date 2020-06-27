using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // Create an instance of a motorcycle
    public class Motorcycle : Vehicle
    {
        public enum eTypeOfLicence
        {
            A, A1, AA, B
        }

        private int m_EngineVolume;
        private eTypeOfLicence m_TypeOfLicence;

        public Motorcycle(int i_EngineVolume, eTypeOfLicence i_TypeOfLicence, string i_ModelName, List<Wheel> i_WheelList, Engine i_Engine, float i_EnergyPercent, string i_LicenseNumber, Dictionary<string, string> i_VehicleInfo) : base(i_ModelName, i_WheelList, i_Engine, i_EnergyPercent, i_LicenseNumber, i_VehicleInfo)
        {
            this.m_EngineVolume = i_EngineVolume;
            this.m_TypeOfLicence = i_TypeOfLicence;
        }

        public int EngineVolume
        {
            get
            {
                return this.m_EngineVolume;
            }

            set
            {
                this.m_EngineVolume = value;
            }
        }

        public eTypeOfLicence LicenceType
        {
            get
            {
                return this.m_TypeOfLicence;
            }

            set
            {
                this.m_TypeOfLicence = value;
            }
        }

        // Return a list of a specific info of a motorcycle
        public static Dictionary<string, string> GeneralMotorcycleInfo()
        {
            StringBuilder LisenceAvailable = new StringBuilder();
            LisenceAvailable.Append("Choose one of the types below:" + Environment.NewLine);
            foreach (eTypeOfLicence type in Enum.GetValues(typeof(eTypeOfLicence)))
            {
                LisenceAvailable.Append(type.ToString() + Environment.NewLine);
            }

            string engineVolume = string.Empty;
            string licenseType = string.Empty;
            Dictionary<string, string> motorcycleInfo = new Dictionary<string, string>() { { "Engine Volume", engineVolume }, { LisenceAvailable.ToString(), licenseType } };
            return motorcycleInfo;
        }

        // Check extra data 
        public static Dictionary<string, string> CheckExtraData(Dictionary<string, string> i_Parameteres)
        {
            string engineVolume = i_Parameteres.Values.ElementAt(0);
            if (!Validation.CheckIfANumber(engineVolume))
            {
                throw new ArgumentException("Engine Volume: Illegal argument");
            }

            string licenseType = i_Parameteres.Values.ElementAt(1);
            if (!Validation.CheckIfEnum(licenseType, eTypeOfLicence.A))
            {
                throw new FormatException("License Type: please enter a valid Type");
            }

            Dictionary<string, string> resultsParameters = new Dictionary<string, string>();
            resultsParameters.Add("Engine Volume", i_Parameteres.Values.ElementAt(0));
            resultsParameters.Add("License Type", i_Parameteres.Values.ElementAt(1));
            return resultsParameters;
        }
    }
}
