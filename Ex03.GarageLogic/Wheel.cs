using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // Create an instance of a wheel
    public class Wheel
    {
        private string m_NameOfManufacturer;
        private float m_CurrentAirPressure;
        private float m_MaximalAirPressure;

        public Wheel(string i_NameOfManufacturer, float i_CurrentAirPressure, float i_MaximalAirPressure = 0)
        {
            this.m_NameOfManufacturer = i_NameOfManufacturer;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
            this.m_MaximalAirPressure = i_MaximalAirPressure;
        }

        // Fill air pressure
        public void FillAirPressure(float i_AirPressureToBlow)
        {
            float totalAirPressureAfterBlowing = i_AirPressureToBlow + this.m_CurrentAirPressure;

            if (!(totalAirPressureAfterBlowing > this.m_MaximalAirPressure))
            {
                this.m_CurrentAirPressure = totalAirPressureAfterBlowing;
            }
        }

        // return weel info
        public string WheelInformation(List<Wheel> i_WheelsOfCar)
        {
            int wheel = 1;
            StringBuilder information = new StringBuilder();
            foreach (Wheel currentWheel in i_WheelsOfCar)
            {
                string nameOfManufecture = currentWheel.NameOfManufacturer;
                float airPressure = currentWheel.CurrentAirPressure;
                string currentCar = string.Format("Wheel number {0}: Manufacturer name: {1}, air pressure: {2}\n", wheel, nameOfManufecture, airPressure);
                information.Append(currentCar);
                wheel++;
            }

            return information.ToString();
        }

        public string NameOfManufacturer
        {
            get
            {
                return this.m_NameOfManufacturer;
            }

            set
            {
                this.m_NameOfManufacturer = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return this.m_CurrentAirPressure;
            }

            set
            {
                this.m_CurrentAirPressure = value;
            }
        }

        public float MaximalAirPressure
        {
            get
            {
                return this.m_MaximalAirPressure;
            }

            set
            {
                this.m_MaximalAirPressure = value;
            }
        }

        // Create weel list by a number of weels
        public static List<Wheel> CreateWheelList(int i_NumOfWheels, Wheel i_Wheel)
        {
            List<Wheel> ListOfWheels = new List<Wheel>();

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Wheel addWheel = new Wheel(i_Wheel.NameOfManufacturer, i_Wheel.CurrentAirPressure, i_Wheel.MaximalAirPressure);
                ListOfWheels.Add(addWheel);
            }

            return ListOfWheels;
        }

        // return a dict with weel info
        public static Dictionary<string, string> WheelInfo()
        {
            Dictionary<string, string> wheelInfo = new Dictionary<string, string>();
            string wheelManufacture = string.Empty;
            string wheelCurPressureToParse = string.Empty;
            string maxAirPressureToParse  = string.Empty;

            wheelInfo.Add("Type Of Wheel", wheelManufacture);
            wheelInfo.Add("Current Wheel Pressure", wheelCurPressureToParse);
            wheelInfo.Add("Maximal Air Pressure", maxAirPressureToParse);
            
            return wheelInfo;
        }
    }
}
