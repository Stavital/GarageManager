using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    // A class with validation for ConsoleUI methods
    internal class ValidtysUI
    {
        // Checks if a string is a number (int) and is between min and max (int)
        internal static bool CheckMainPickValidity(string i_UserPick, int i_Min, int i_Max)
        {
            bool isValid = true;
            int userIntegerPick = 0;
            bool isInt = int.TryParse(i_UserPick, out userIntegerPick);

            if (!isInt)
            {
                return false;
            }

            if (userIntegerPick < i_Min || userIntegerPick > i_Max)
            {
                isValid = false;
            }

            return isValid;
        }
        
        // Checks if a string is a number (float) and if its lower then a different number (as string)
        internal static void CheckInputValidity(string i_CurrentInput, string i_MaxInput)
        {
            float maxInput = float.Parse(i_MaxInput);
            float currentInput = 0;
            bool current = float.TryParse(i_CurrentInput, out currentInput);
            
            if (!current)
            {
                // throws an exeption if not a number
                throw new FormatException("Please enter a number");
            } 

            if (currentInput > maxInput)
            {
                // throws an expetion if higher then max
                throw new ArgumentException("Current input must be lower then maximum available");
            }
        }

        // Checks if a string is a number throw an exception otherwise
        internal static void CheckIfANumber(string i_MaxInput)
        {
            bool isNumber = float.TryParse(i_MaxInput, out float maxPressue);

            if (!isNumber)
            {
                throw new FormatException("Please enter a number");
            }
        }

        // check if a given string fits a valid fuel type throws an exception otherwise
        internal static void CheckFuelType(string i_FuelType)
        {
            int count = Enum.GetNames(typeof(FuelEngine.eFuelType)).Length;
            bool tryParse = int.TryParse(i_FuelType, out int choosenType);
            if (!tryParse)
            {
                throw new FormatException("Please choose a number");
            }

            if(choosenType > count || choosenType < 0)
            {
                throw new ArgumentException("The number is Illegal");
            }
        }
    } 
}