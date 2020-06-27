using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // Create an instance of an electric engine
    internal class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxEnergy, float i_EnergyLeft, eEngineType i_EngineType) :
            base(i_MaxEnergy, i_EnergyLeft, i_EngineType)
        {
        }

        // Fill energy in a car, throw ArgumentException is a car in not electric
        internal void FillEnergy(float i_EnergyToCharge)
        {
            if (m_EnergyLeft + i_EnergyToCharge > m_MaximumEnergy)
            {
                float minimunChargingAmount = 0;
                float maximunChargingAmount = m_MaximumEnergy - m_EnergyLeft;
                throw new ValueOutOfRangeException(minimunChargingAmount, maximunChargingAmount);
            }

            this.m_EnergyLeft += i_EnergyToCharge;
        }
    }
}
