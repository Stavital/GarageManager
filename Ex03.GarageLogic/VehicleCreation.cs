using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleCreation
    {
        public enum eVehicleType
        {
            Motorcycle, Car, Truck
        }

        private readonly Dictionary<string, string> r_Parametres;
        private readonly eVehicleType r_Vehicletype;
        private string m_LicenceNumber;
        private string m_ModelType;
        private float m_EnergyLeft;
        private int m_AmountOfConstParams;
        private string m_Enginetype;
        private Vehicle m_Vehicle;

        public VehicleCreation(Dictionary<string, string> i_Parametres, eVehicleType i_VehicleType)
        {
            r_Parametres = i_Parametres;
            r_Vehicletype = i_VehicleType;
            m_AmountOfConstParams = i_Parametres.Count();
            r_Parametres.TryGetValue("Licence Number", out m_LicenceNumber);
            r_Parametres.TryGetValue("Model Type", out m_ModelType);
            r_Parametres.TryGetValue("Engine Type", out m_Enginetype);

            if (i_VehicleType == eVehicleType.Car)
            {
                CreateCar();
            }

            if (i_VehicleType == eVehicleType.Motorcycle)
            {
                CreateMotorcycle();
            }

            if (i_VehicleType == eVehicleType.Truck)
            {
                CreateTruck();
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return this.m_Vehicle;
            }
        }

        public Dictionary<string, string> Parameters
        {
            get
            {
                return this.r_Parametres;
            }
        }

        // Create an engine
        private Engine CreateEngine(string i_EngineType)
        {
            this.r_Parametres.TryGetValue("Amount Of Energy Left", out string AmountOfEnergyParse);
            float amountOfEnergy = float.Parse(AmountOfEnergyParse);

            this.r_Parametres.TryGetValue("Max energy", out string engineCapacityParse);
            float energeyCapacity = float.Parse(engineCapacityParse);

            Engine engine = null;
            if (i_EngineType.Equals("Electric"))
            {
                engine = new ElectricEngine(energeyCapacity, amountOfEnergy, Engine.eEngineType.Electric);
            }
            else
            {
                this.r_Parametres.TryGetValue("Fuel Kind", out string fuelTypeParse);
                Enum.TryParse<FuelEngine.eFuelType>(fuelTypeParse, out FuelEngine.eFuelType fuelType);
                engine = new FuelEngine(energeyCapacity, amountOfEnergy, Engine.eEngineType.Fuel, fuelType);
            }

            return engine;
        }

        // Crate weel
        private Wheel CreateWheel()
        {
            string wheelManufacturer;
            float wheelCurPressure;
            float maxAirPressure;
            this.r_Parametres.TryGetValue("Type Of Wheel", out wheelManufacturer);
            this.r_Parametres.TryGetValue("Current Wheel Pressure", out string wheelCurPressureToParse);
            this.r_Parametres.TryGetValue("Maximal Air Pressure", out string maxAirPressureToParse);
            maxAirPressure = float.Parse(maxAirPressureToParse);
            wheelCurPressure = float.Parse(wheelCurPressureToParse);
            Wheel wheel = new Wheel(wheelManufacturer, wheelCurPressure, maxAirPressure);

            return wheel;
        }

        // Crate car
        public void CreateCar()
        {
            string numberOfDoorsParse = r_Parametres.Values.ElementAt(m_AmountOfConstParams - 1);
            int numberOfDoors = int.Parse(numberOfDoorsParse);

            string carColor = r_Parametres.Values.ElementAt(m_AmountOfConstParams - 2);
            Enum.TryParse<Car.eColorOfCar>(carColor, out Car.eColorOfCar colorOfCar);

            Wheel CarWheel = CreateWheel();
            List<Wheel> wheelList = Wheel.CreateWheelList(4, CarWheel);
            Engine engine = CreateEngine(m_Enginetype);

            m_Vehicle = new Car(colorOfCar, numberOfDoors, m_ModelType, wheelList, engine, m_EnergyLeft, m_LicenceNumber, r_Parametres);
        }

        // Create morotcycle
        public void CreateMotorcycle()
        {
            string engineVolumeParse = r_Parametres.Values.ElementAt(m_AmountOfConstParams - 2);
            int engineVolume = int.Parse(engineVolumeParse);

            string licenceTypeParse = r_Parametres.Values.ElementAt(m_AmountOfConstParams - 1);
            Enum.TryParse<Motorcycle.eTypeOfLicence>(licenceTypeParse, out Motorcycle.eTypeOfLicence licenceType);
            
            Wheel MotorcycleWheel = CreateWheel();
            List<Wheel> wheelList = Wheel.CreateWheelList(2, MotorcycleWheel);
            Engine engine = CreateEngine(m_Enginetype);

            m_Vehicle = new Motorcycle(engineVolume, licenceType, m_ModelType, wheelList, engine, m_EnergyLeft, m_LicenceNumber, r_Parametres);
        }

        // Create truck
        public void CreateTruck()
        {
            string isDangerousAsString = r_Parametres.Values.ElementAt(m_AmountOfConstParams - 2);
            bool isDangerous = false;
            if (isDangerousAsString == "1") 
            {
                isDangerous = true;
            } 

            string volumeAsString = r_Parametres.Values.ElementAt(m_AmountOfConstParams - 1);
            float cargoVolume = float.Parse(volumeAsString);
            Wheel truckWheel = CreateWheel();
            Engine engine = CreateEngine(m_Enginetype);

            List<Wheel> wheelList = Wheel.CreateWheelList(12, truckWheel);

            m_Vehicle = new Truck(isDangerous, cargoVolume, m_ModelType, wheelList, engine, m_EnergyLeft, m_LicenceNumber, r_Parametres);
        }

        // Adds specific info
        public static Dictionary<string, string> AddSpecInfo(eVehicleType i_VehicleType, Dictionary<string, string> i_Parameteres)
        {
            Dictionary<string, string> checkedValues = new Dictionary<string, string>();
            switch (i_VehicleType)
            {
                case eVehicleType.Truck:
                    checkedValues = Truck.CheckExtraData(i_Parameteres);
                    break;

                case eVehicleType.Car:
                    checkedValues = Car.CheckExtraData(i_Parameteres);
                    break;

                case eVehicleType.Motorcycle:
                    checkedValues = Motorcycle.CheckExtraData(i_Parameteres);
                    break;
            }

            return checkedValues;
        }
    }
 }
