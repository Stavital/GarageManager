using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    //// Create an instance of a engine
    public class Engine
    {
        internal float m_EnergyLeft;
        internal float m_MaximumEnergy;

        public enum eEngineType
        {
            Electric,
            Fuel
        }

        private eEngineType m_Enginetype;

        public Engine(float i_MaxEnergy, float i_EnergyLeft, eEngineType i_EngineType)
        {
            this.m_EnergyLeft = i_EnergyLeft;
            this.m_MaximumEnergy = i_MaxEnergy;
            this.m_Enginetype = i_EngineType;
        }

        public string TypeOfEngine
        {
            get
            {
                return this.m_Enginetype.ToString();
            }
        }

        public float EnergyLeft
        {
            get
            {
                return this.m_EnergyLeft;
            }
        }

        public float MaximumEnergy
        {
            get
            {
                return this.m_MaximumEnergy;
            }
        }
    }
}