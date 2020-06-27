using System;
using System.Text;
using System.Threading;

namespace Ex03.ConsoleUI
{
    // Make a new garage and give all the operations.
    public class GarageUI
    {
        private static GarageOperations Operation;
        private readonly GarageLogic.Garage r_Garage;

        public GarageUI()
        {
            // Welcome message
            Console.WriteLine("welcome to the Garage Manager");
            Thread.Sleep(1200);
            r_Garage = new GarageLogic.Garage();
            Operation = new GarageOperations();
            // Start Garage
            StartGarage();

            Console.WriteLine("Thank you for chosing Garage Manager");
            Console.WriteLine("Press any key to Exit");
        }

        // Starts  and runs the Garage Manager App
        public void StartGarage()
        {
            bool open = true;

            // While open = true, keep garage open
            while (open)
            {
                Console.Clear();
                // Prints Garage Main menu and get an input to deal with
                PrintMainMenu();
                Console.WriteLine("Your Option: ");
                string optionPicked = Console.ReadLine();

                // Checks if input is legal
                while (!ValidtysUI.CheckMainPickValidity(optionPicked, 1, 8))
                {
                    Console.WriteLine("Illegal input, Please pick a number between 1 to 8: ");
                    optionPicked = Console.ReadLine();
                }

                Console.Clear();

                // Choose an action for chosen input
                switch (optionPicked)
                {
                    case "1":
                        Operation.AddVehicle(r_Garage);
                        break;

                    case "2":
                        Operation.GetVehicleList(r_Garage);
                        break;

                    case "3":
                        Operation.ChangeVehicleStatus(r_Garage);
                        break;

                    case "4":
                        Operation.ChargeElectricVehicle(r_Garage);
                        break;

                    case "5":
                        Operation.FillGas(r_Garage);
                        break;

                    case "6":
                        Operation.FillAirInVehiclesWheels(r_Garage);
                        break;

                    case "7":
                        Operation.ShowFullVehicleDetails(r_Garage);
                        break;

                    case "8":
                        open = false;
                        Console.Clear();
                        break;
                }
            }
        }

        // Prints Main Menu of the Garage
        private void PrintMainMenu()
        {
            StringBuilder mainMenu = new StringBuilder();
            mainMenu.Append("Please pick and option from the Main Menu" + Environment.NewLine);
            mainMenu.Append("========================================" + Environment.NewLine);
            mainMenu.Append("1. Add new Veihcle to the garage" + Environment.NewLine);
            mainMenu.Append("2. Get Vehicles list" + Environment.NewLine);
            mainMenu.Append("3. Change Vehicle status" + Environment.NewLine);
            mainMenu.Append("4. Charge electric vehicle engine" + Environment.NewLine);
            mainMenu.Append("5. Fill gas for Fuel Engine Vehicle" + Environment.NewLine);
            mainMenu.Append("6. Fill Air in Vehicle's wheels" + Environment.NewLine);
            mainMenu.Append("7. Show full Vehicle details by license number" + Environment.NewLine);
            mainMenu.Append("8. Quit Application" + Environment.NewLine);

            Console.WriteLine(mainMenu.ToString());
        }
    }
}