using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // main class managing the garage logic
    public class Garage
    {
        public enum eCarStatus
        {
            Maintenence, Repaired, Paid
        }

        public enum TypeOfVehicals
        {
            Car,
            Motorcycle,
            Truck
        }

        private Dictionary<string, Customer> m_Customers = new Dictionary<string, Customer>();

        /** creates customer and adds it to garage
        * if exist, change Vehicle status to maintenence
        * return to User if Vehicle is already in garage
        **/
        public void AddCustomer(string i_Name, string i_PhoneNumber, Vehicle i_Vehicle)
        {
            Customer newCustomer = new Customer(i_Name, i_PhoneNumber, eCarStatus.Maintenence, i_Vehicle);
            m_Customers.Add(newCustomer.LicenseNumber, newCustomer);
        }

        /** change customer's Vehicle status by license number and desired Vehicle status
        * if the Vehicle does not exist in the garage, return false
        **/
        public void ChangeCarStatus(string i_LicenseNumber, eCarStatus i_VehicleStatus)
        {
            m_Customers[i_LicenseNumber].Status = i_VehicleStatus;
        }

        // return a list of the Vehicles in the garage by the Vehicle status
        public List<string> GetCustomersList(string i_VehicleStatus)
        {
            List<string> currentVehiclesInGarage = new List<string>();
            foreach (KeyValuePair<string, Customer> vehicle in m_Customers)
            {
                if (i_VehicleStatus == "3")
                {
                    currentVehiclesInGarage.Add(vehicle.Key + " - " + vehicle.Value.Status);
                }

                eCarStatus chosenStatus;
                bool status = Enum.TryParse<eCarStatus>(i_VehicleStatus, out chosenStatus);
                if (vehicle.Value.Status.Equals(chosenStatus))
                {
                    currentVehiclesInGarage.Add(vehicle.Key + " - " + vehicle.Value.Status);
                }
            }

            return currentVehiclesInGarage;
        }

        // checks if customer's vehicle is already in the garage
        public bool IsInGarage(string i_LicenseNumber)
        {
            bool inGarage = true;
            if (!m_Customers.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentNullException("Vehicle does not exsit in the garage");
            }

            return inGarage;
        }

        // checks if a vehicle is not in garage and throws an excpetion
        public bool IsNotInGarage(string i_LicenseNumber)
        {
            bool isNotInGarage = true;
            if (m_Customers.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentNullException("Vehicle does not exsit in the garage");
            }

            return isNotInGarage;
        }

        // responsible to fill air pressure to max pressure
        public void FillAirPressure(string i_LicenseNumber)
        {
            Customer currentCustomer = m_Customers[i_LicenseNumber];
            List<Wheel> wheelsOfCar = currentCustomer.CustomerVehicle.WheelList;
            List<Wheel> wheelAfterFilling = new List<Wheel>();
            foreach (Wheel wheel in wheelsOfCar)
            {
                float maxPressure = wheel.MaximalAirPressure;
                float currentPressure = wheel.CurrentAirPressure;
                wheel.FillAirPressure(maxPressure - currentPressure);
                wheelAfterFilling.Add(wheel);
            }

            currentCustomer.CustomerVehicle.WheelList = wheelAfterFilling;
            m_Customers[i_LicenseNumber] = currentCustomer;
        }

        // resposible to validate data and charge engine
        public void ChargeEnergy(string i_LicenseNumber, float i_MinutesToCharge)
        {
            Customer currentCar = m_Customers[i_LicenseNumber];
            if (currentCar.CustomerVehicle.VehicleEngine.TypeOfEngine  != "Electric")
            {
                throw new Exception("this Vehicle is not electric Vehicle");
            }
            
            ElectricEngine engineToCharge = (ElectricEngine)currentCar.CustomerVehicle.VehicleEngine;

            float HowMuchToCharge = i_MinutesToCharge / 60;
            engineToCharge.FillEnergy(HowMuchToCharge);
        }

        // resposible to validate data and fill up gas
        public void FillUpGas(string i_LicenseNumber, FuelEngine.eFuelType i_FuelType, float i_AmountToFill)
        {
            Customer currentCar = m_Customers[i_LicenseNumber];

            if (currentCar.CustomerVehicle.VehicleEngine.TypeOfEngine != "Fuel")
            {
                throw new Exception("this Vehicle is an electric Vehicle");
            }

            FuelEngine engineToFill = (FuelEngine) currentCar.CustomerVehicle.VehicleEngine;
            engineToFill.FillFuel(i_AmountToFill, i_FuelType);
        }

        // shows all owner + vehicle + specific vehicle details
        public string ShowDetails(string i_LicenseNumber)
        {
            Customer currentCar = m_Customers[i_LicenseNumber];
            string vehicleModel = currentCar.CustomerVehicle.ModelName;
            string ownerName = currentCar.Name;
            string vehicleStatus = currentCar.Status.ToString();
            List<Wheel> WheelsOfCar = currentCar.CustomerVehicle.WheelList;
            int numberOfWheels = WheelsOfCar.Count;
            StringBuilder wheelsInformation = new StringBuilder();
            
            foreach (Wheel wheel in WheelsOfCar)
            {
                string currentWheelInformation = wheel.WheelInformation(WheelsOfCar);
                wheelsInformation.Append(currentWheelInformation);
                break;
            }
            
            string vehicleInformation = string.Format("Information about the vehicle with licenseNumber {0} : " + Environment.NewLine + "Model : {1}" + Environment.NewLine + 
                "Owner Name : {2}" + Environment.NewLine + "Car status : {3}" +Environment.NewLine + "There are {4} Wheels :" +Environment.NewLine + "{5}", i_LicenseNumber, vehicleModel, ownerName, vehicleStatus, numberOfWheels, wheelsInformation);

            Engine currentCarEngine = currentCar.CustomerVehicle.VehicleEngine;
            float energyLeft;
            string kindOfFuel;
            string engineInformation = string.Empty;
            if (currentCarEngine.TypeOfEngine == "Fuel")
            {
                FuelEngine fuelEngine = currentCarEngine as FuelEngine;
                energyLeft = fuelEngine.EnergyLeft;
                kindOfFuel = fuelEngine.TypeOfFuel.ToString();
                engineInformation = string.Format("Fuel: {0} , {1} liters left" + Environment.NewLine, kindOfFuel, energyLeft);
            }
            else
            {
                ElectricEngine electricEngine = currentCarEngine as ElectricEngine;
                energyLeft = electricEngine.EnergyLeft;
                engineInformation = string.Format("Battry left {0}" + Environment.NewLine , energyLeft);
            }

            string moreParameters = ShowSpacielDeatils(currentCar);

            return vehicleInformation + engineInformation + moreParameters;
        }

        // shows wpecific vehicle details
        private string ShowSpacielDeatils(Customer io_CurrentCar)
        {
            string deatils = io_CurrentCar.CustomerVehicle.PrintSpaiclParameters();
            return deatils;
        }
    }
}