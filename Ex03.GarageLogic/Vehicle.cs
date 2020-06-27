using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // Create an instance of a vehicle
    public class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyPercent;
        private List<Wheel> m_WheelList;
        private Engine m_Engine;
        private Dictionary<string, string> m_VehicleInfo;
        private string m_TypeOfEngine;

        public Vehicle(string i_ModelName, List<Wheel> i_Wheel, Engine i_Engine, float i_CurrentEnergy, string i_LicenseNumber, Dictionary<string, string> i_VehicleInfo)
        {
            this.m_ModelName = i_ModelName;
            this.m_WheelList = i_Wheel;
            this.m_EnergyPercent = i_CurrentEnergy;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_Engine = i_Engine;
            this.m_VehicleInfo = i_VehicleInfo;
            m_TypeOfEngine = i_Engine.TypeOfEngine.ToString();
        }

        public string ModelName
        {
            get
            {
                return this.m_ModelName;
            }

            set
            {
                this.m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this.m_LicenseNumber;
            }

            set
            {
                this.m_LicenseNumber = value;
            }
        }
        
        public float EnergyPercent
        {
            get
            {
                return this.m_EnergyPercent;
            }

            set
            {
                this.m_EnergyPercent = value;
            }
        }

        public List<Wheel> WheelList
        {
            get
            {
                return this.m_WheelList;
            }

            set
            {
                this.m_WheelList = value;
            }
        }

        public Engine VehicleEngine
        {
            get
            {
                return this.m_Engine;
            }

            set
            {
                this.m_Engine = value;
            }
        }

        // return a string with a spesific info
        public string PrintSpaiclParameters()
        {
            int count = m_VehicleInfo.Count();
            string firstKey = m_VehicleInfo.Keys.ElementAt(count - 1).ToString();
            string firstValue = m_VehicleInfo.Values.ElementAt(count - 1).ToString();
            string secondKey = m_VehicleInfo.Keys.ElementAt(count - 2).ToString();
            string secondValue = m_VehicleInfo.Values.ElementAt(count - 2).ToString();

            string allParameters = string.Format("{0}: {1}" + Environment.NewLine + "{2}: {3}" + Environment.NewLine , firstKey, firstValue, secondKey, secondValue);
            return allParameters;
        }
    }
}
