using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    // Class for calling all the garage operations.
    public class GarageOperations
    {
        private string m_CurrentLicnese;

        internal GarageOperations()
        {
            m_CurrentLicnese = string.Empty;
        }

        // Adds a vehicle to the garage, if vehicle is already in the garage, sets status as maintenence
        internal void AddVehicle(GarageLogic.Garage i_Garage)
        {
            string vehicle = string.Empty;
            Dictionary<string, string> parametrs = new Dictionary<string, string>();
            string licenseNumber = string.Empty;
            string typeOfWheels = string.Empty;
            string modelType = string.Empty;
            bool validationFlag = false;
            string name = string.Empty;
            string phoneNumber = string.Empty;

            Console.Clear();
            // Gets license number, if already exists change status to maintenence
            Console.WriteLine("Enter License Number");
            licenseNumber = Console.ReadLine();
            try
            {
                i_Garage.IsNotInGarage(licenseNumber);
            }
            catch
            {
                i_Garage.ChangeCarStatus(licenseNumber, Garage.eCarStatus.Maintenence);
                Console.WriteLine("Vehicle already in garage, status changes to maintenence");
                Thread.Sleep(1200);
                return;
            }
            
            Console.Clear();

            // get customer inforamtion
            Console.WriteLine("Please write your name");
            name = Console.ReadLine();
            Console.WriteLine("Please write your phone number");
            phoneNumber = Console.ReadLine();

            Console.Clear();

            // get and validate vehicle type
            System.Console.WriteLine("Please enter your vehicle type, those are the vehicle we support:");
            int i = 0;

            foreach (VehicleCreation.eVehicleType typeOfCar in Enum.GetValues(typeof(VehicleCreation.eVehicleType)))
            {
                System.Console.WriteLine("* For " + typeOfCar.ToString() + " Press " + i);
                i++;
            }
            
            while (!validationFlag)
            {
                try
                {
                    vehicle = System.Console.ReadLine();
                    validationFlag = Validation.TypeOfVehicle(vehicle);
                }
                catch (Exception e)
                {
                    validationFlag = false;
                    System.Console.WriteLine(e.Message);
                }
            }

            parametrs.Add("Licence Number", licenseNumber);
            parametrs.Add("Vehicle Type", vehicle.ToString());
            Enum.TryParse<VehicleCreation.eVehicleType>(vehicle, out VehicleCreation.eVehicleType vehicleType);

            // get Vehicle Model
            Console.WriteLine("Please enter vehicle model");
            modelType = Console.ReadLine();
            parametrs.Add("Model Type", modelType);

            Console.Clear();

            // get wheels information
            System.Console.WriteLine("please enter the type of your wheels");
            typeOfWheels = Console.ReadLine();
            parametrs.Add("Type Of Wheel", typeOfWheels);

            string maxAirPressure  = string.Empty;
            System.Console.WriteLine("Please enter the max air of your wheels");
            bool isNumber = false;

            while (!isNumber)
            {
                maxAirPressure = Console.ReadLine();
                try
                {
                    ValidtysUI.CheckIfANumber(maxAirPressure);
                    isNumber = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            isNumber = false;
            parametrs.Add("Maximal Air Pressure", maxAirPressure);

            string currentAirPressure = string.Empty;
            System.Console.WriteLine("Please enter the current air of your wheels");
            bool isVaildAir = false;
            while (!isVaildAir)
            {
                currentAirPressure = Console.ReadLine();
                try
                {
                    ValidtysUI.CheckInputValidity(currentAirPressure, maxAirPressure);
                    isVaildAir = true;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            parametrs.Add("Current Wheel Pressure", currentAirPressure);

            Console.Clear();

            // get engine information
            string maximumEnergy = string.Empty;
            bool isValid = false;
            Console.WriteLine("Please enter the maximun energy of your vehicle");

            while (!isNumber)
            {
                maximumEnergy = Console.ReadLine();
                try
                {
                    ValidtysUI.CheckIfANumber(maximumEnergy);
                    isNumber = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            parametrs.Add("Max energy", maximumEnergy);

            string energyLeft = string.Empty;
            Console.WriteLine("Please enter the enregy left in the vehicle");

            while (!isValid)
            {
                energyLeft = Console.ReadLine();
                try
                {
                    ValidtysUI.CheckInputValidity(energyLeft, maximumEnergy);
                    isValid = true;
                } 
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                } 
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            parametrs.Add("Amount Of Energy Left", energyLeft);

            Console.WriteLine("Is the vehicle electric?");
            Console.WriteLine("1. yes");
            Console.WriteLine("2. no");

            string answer = Console.ReadLine();
            Engine.eEngineType type = Engine.eEngineType.Electric;
            bool isOneOrTwo = false;
            while (!isOneOrTwo)
            {
                if (answer == "1")
                {
                    type = Engine.eEngineType.Electric;
                    isOneOrTwo = true;
                }

                if (answer == "2")
                {
                    type = Engine.eEngineType.Fuel;
                    int numberOfChoice = 1;
                    Console.WriteLine("Please pick one of the Fuel types below: ");

                    // iterate through gas types available and prints them
                    foreach (GarageLogic.FuelEngine.eFuelType fuelType in Enum.GetValues(typeof(GarageLogic.FuelEngine.eFuelType)))
                    {
                        Console.WriteLine(numberOfChoice + ". " + fuelType.ToString());
                        numberOfChoice++;
                    }

                    bool isFuelType = false;
                    string chosenFuelType = string.Empty;
                    while (!isFuelType)
                    {
                        chosenFuelType = Console.ReadLine();
                        try
                        {
                            ValidtysUI.CheckFuelType(chosenFuelType);

                            Array enumValues = Enum.GetValues(typeof(FuelEngine.eFuelType));
                            int chosenAsInt = int.Parse(chosenFuelType) - 1;
                            parametrs.Add("Fuel Kind", enumValues.GetValue(chosenAsInt).ToString());
                            isFuelType = true;
                        } 
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        } 
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    isOneOrTwo = true;
                }

                if (answer != "1" && answer != "2")
                {
                    Console.WriteLine("please enter 1 or 2");
                    answer = Console.ReadLine();
                }
            }

            parametrs.Add("Engine Type", type.ToString());
            Console.Clear();

            ExpendVehicleParameter(vehicleType, parametrs);
            VehicleCreation BuildVehicle = new VehicleCreation(parametrs, vehicleType);
            Vehicle newVehicle = BuildVehicle.Vehicle;
            i_Garage.AddCustomer(name, phoneNumber, newVehicle);

            // show success message and takes back to main menu
            SuccessFinishOperation();
        }

        // Adds specific vehicle type info
        private static void ExpendVehicleParameter(VehicleCreation.eVehicleType i_VehicleType, Dictionary<string, string> io_Parameters)
        {
            Dictionary<string, string> aditionalInfo = AdditionalInfo.AditionalInfo(i_VehicleType);
            Dictionary<string, string> extraInfo = new Dictionary<string, string>();
            bool validationFlag = false;

            while (!validationFlag)
            {
                foreach (string info in aditionalInfo.Keys.ToList())
                {
                    System.Console.WriteLine(info + " ");
                    aditionalInfo[info] = System.Console.ReadLine();
                }
                
                try
                {
                    extraInfo = VehicleCreation.AddSpecInfo(i_VehicleType, aditionalInfo); 
                    validationFlag = true;
                }
                catch (Exception e)
                {
                    validationFlag = false;
                    System.Console.WriteLine(e.Message);
                }
            }

            foreach (KeyValuePair<string, string> info in extraInfo)
            {
                io_Parameters.Add(info.Key, info.Value);
            }
        }

        // Print a list of vehicles in the garage by filter of vehicle status
        internal void GetVehicleList(GarageLogic.Garage i_Garage)
        {
            int option = 0;

            Console.WriteLine("To Filter by status pick a number of option below: ");

            // iterate through car statuses available and print them
            foreach (GarageLogic.Garage.eCarStatus status in Enum.GetValues(typeof(GarageLogic.Garage.eCarStatus)))
            {
                Console.WriteLine(option + ". " + status.ToString());
                option++;
            }

            Console.WriteLine("For default view press 3");

            // sets and validate a car status to change to
            string optionUserPicked = Console.ReadLine();

            while (!ValidtysUI.CheckMainPickValidity(optionUserPicked, 0, option))
            {
                Console.WriteLine("Illegal input, Please pick a number between 0 to " + option);
                optionUserPicked = Console.ReadLine();
            }

            // printing customers list with according filtering
            List<string> customersList = i_Garage.GetCustomersList(optionUserPicked);

            if (customersList.Count() == 0)
            {
                Console.WriteLine("No customers with required status are in the Garage, or no customers at all");
            } 
            else
            {
                foreach (string customer in customersList)
                {
                    Console.WriteLine(customer);
                }
            }

            // show success message and takes back to main menu
            SuccessFinishOperation();
        }

        // Change vehicle status
        internal void ChangeVehicleStatus(GarageLogic.Garage i_Garage)
        {
            // gets license number and checks if exist in garage, if not may exit to main menu
            m_CurrentLicnese = GetLicense(i_Garage);
            if (m_CurrentLicnese.Equals("-1")) 
            {
                return;
            } 

            Dictionary<string, GarageLogic.Garage.eCarStatus> statuses = new Dictionary<string, GarageLogic.Garage.eCarStatus>();

            int number = 1;
            Console.WriteLine("Please pick one of the Statuses below: ");

            // iterate through car statuses available and print them
            foreach (GarageLogic.Garage.eCarStatus status in Enum.GetValues(typeof(GarageLogic.Garage.eCarStatus)))
            {
                Console.WriteLine(number + ". " + status.ToString());
                statuses.Add(number.ToString(), status);
                number++;
            }

            number--;

            // sets and validate a car status to change to
            string statusPicked = Console.ReadLine();

            while(!ValidtysUI.CheckMainPickValidity(statusPicked, 1, number))
            {
                Console.WriteLine("Illegal input, Please pick a number between 1 to " + number);
                statusPicked = Console.ReadLine();
            }

            // changes car status
            i_Garage.ChangeCarStatus(m_CurrentLicnese, statuses[statusPicked]);

            // show success message and takes back to main menu
            SuccessFinishOperation();
        }

        // charge energy for an existing suitable type vehicle
        internal void ChargeElectricVehicle(GarageLogic.Garage i_Garage)
        {
            // gets license number and checks if exist in garage, if not may exit to main menu
            m_CurrentLicnese = GetLicense(i_Garage);
            if (m_CurrentLicnese.Equals("-1"))
            {
                return;
            }

            // sets and validate amount of minutes to charge vehicle
            Console.WriteLine("Please enter amount of minutes to charge");
            string minutes = Console.ReadLine();
            float minutesToCharge = 0;
            bool isMinutes = float.TryParse(minutes, out minutesToCharge);

            while(!isMinutes)
            {
                Console.WriteLine("Please enter minutes as float number");
                minutes = Console.ReadLine();
                isMinutes = float.TryParse(minutes, out minutesToCharge);
            }

            // try to charge vehicle, if vehicle is not suitable, brings back to main menu
            try
            {
                i_Garage.ChargeEnergy(m_CurrentLicnese, minutesToCharge);
            } 
            catch (Exception)
            {
                Console.WriteLine("This vehicle is not electrical, plase choose a different option in Main Menu");
                Console.WriteLine("Press any key to return to Main Menu");
                Console.ReadLine();
                return;
            }

            // show success message and takes back to main menu
            SuccessFinishOperation();
        }

        // fill gas for an existing suitable type vehicle
        internal void FillGas(GarageLogic.Garage i_Garage)
        {
            // gets license number and checks if exist in garage, if not may exit to main menu
            m_CurrentLicnese = GetLicense(i_Garage);
            if (m_CurrentLicnese.Equals("-1"))
            {
                return;
            }

            int numberOfChoice = 1;
            Dictionary<string, GarageLogic.FuelEngine.eFuelType> fuelTypes = new Dictionary<string, FuelEngine.eFuelType>();

            // checks and validate amount of gas to refill
            Console.WriteLine("Please enter amount of Litres to add");
            string litres = Console.ReadLine();
            float litresToAdd = 0;
            bool isLitres = float.TryParse(litres, out litresToAdd);

            while (!isLitres)
            {
                Console.WriteLine("Please enter minutes as float number");
                litres = Console.ReadLine();
                isLitres = float.TryParse(litres, out litresToAdd);
            }

            Console.WriteLine("Please pick one of the Fuel types below: ");

            // iterate through gas types available and prints them
            foreach (GarageLogic.FuelEngine.eFuelType type in Enum.GetValues(typeof(GarageLogic.FuelEngine.eFuelType)))
            {
                Console.WriteLine(numberOfChoice + ". " + type.ToString());
                fuelTypes.Add(numberOfChoice.ToString(), type);
                numberOfChoice++;
            }

            numberOfChoice--;

            // sets and validate the type of fuel to refill
            string statusPicked = Console.ReadLine();

            while (!ValidtysUI.CheckMainPickValidity(statusPicked, 1, numberOfChoice))
            {
                Console.WriteLine("Illegal input, Please pick a number between 1 to " + numberOfChoice);
                statusPicked = Console.ReadLine();
            }

            // try refuel vehicle, if vehicle is not suitable, brings back to main menu
            try
            {
                i_Garage.FillUpGas(m_CurrentLicnese, fuelTypes[statusPicked],  litresToAdd);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(1500);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(1500);
                return;
            }

            // show success message and takes back to main menu
            SuccessFinishOperation();
        }

        // fill air in an existing vehicle's wheels
        internal void FillAirInVehiclesWheels(GarageLogic.Garage i_Garage)
        {
            // gets license number and checks if exist in garage, if not may exit to main menu
            m_CurrentLicnese = GetLicense(i_Garage);
            if (m_CurrentLicnese.Equals("-1"))
            {
                return;
            }

            // fills air in the vehicle
            i_Garage.FillAirPressure(m_CurrentLicnese);

            // show success message and takes back to main menu
            SuccessFinishOperation();
        }

        // Print all the details of a spesific vehicle
        internal void ShowFullVehicleDetails(GarageLogic.Garage i_Garage)
        {
            // gets license number and checks if exist in garage, if not may exit to main menu
            m_CurrentLicnese = GetLicense(i_Garage);
            if (m_CurrentLicnese.Equals("-1"))
            {
                return;
            }

            Console.WriteLine(i_Garage.ShowDetails(m_CurrentLicnese) + Environment.NewLine);

            i_Garage.ShowDetails(m_CurrentLicnese);

            // show success message and takes back to main menu
            SuccessFinishOperation();
        }

        // Ask for a license number from the user, is the number is not in the garage throw ArgumentNullException 
        private string GetLicense(GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Please Enter License Number");
            string license = Console.ReadLine();
            bool isInGarage = false;
            while (!isInGarage)
            {
                try
                {
                    isInGarage = i_Garage.IsInGarage(license);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("Vehicle is not in the Garage");
                    Console.WriteLine("Press -1 to get back to Main Menu, or any key to retry");
                    string userDecision = Console.ReadLine();
                    if (userDecision == "-1")
                    {
                        license = "-1";
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine(Environment.NewLine + "Re-enter License Number: ");
                    license = Console.ReadLine();
                }
            }

            return license;
        }
        
        // Print succese message and return to main menu
        private void SuccessFinishOperation()
        {
            Console.WriteLine("Opertaion have been done Successfully");
            Console.WriteLine("Press any Key to return to Main Menu");
            Console.ReadLine();
        }
    }
}