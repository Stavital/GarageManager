using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        private float MaxValue
        {
            get
            {
                return this.m_MaxValue;
            }

            set
            {
                this.m_MaxValue = value;
            }
        }

        private float MinValue
        {
            get
            {
                return this.m_MinValue;
            }

            set
            {
                this.m_MinValue = value;
            }
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) : base(string.Format("Value must be between {0} to {1}", i_MinValue, i_MaxValue))
        {
            this.m_MinValue = i_MinValue;
            this.m_MaxValue = i_MaxValue;
        }
    }
}
