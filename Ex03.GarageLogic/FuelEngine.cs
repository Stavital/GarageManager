using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // // Create an instance of a fuel engine
    public class FuelEngine : Engine
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private readonly eFuelType r_FuelType;

        public FuelEngine(float i_MaxEnergy, float i_EnergyLeft, eEngineType i_EngineType, eFuelType i_FuelType) :
            base(i_MaxEnergy, i_EnergyLeft, i_EngineType)
        {
            this.r_FuelType = i_FuelType;
        }

        public eFuelType TypeOfFuel
        {
            get
            {
                return this.r_FuelType;
            }
        }

        // Fill fuel in a car, throw ArgumentException is a car is an electric car
        public void FillFuel(float i_EnergyToCharge, eFuelType i_FuelType)
        {
            if (m_EnergyLeft + i_EnergyToCharge > m_MaximumEnergy)
            {
                float minimunChargingAmount = 0;
                float maximunChargingAmount = m_MaximumEnergy - m_EnergyLeft;
                throw new ValueOutOfRangeException(minimunChargingAmount, maximunChargingAmount);
            }
            
            if (!this.r_FuelType.Equals(i_FuelType))
            {
                throw new ArgumentException("Wrong fuel type");
            }

            this.m_EnergyLeft += i_EnergyToCharge;
        }
    }
}
