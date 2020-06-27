using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // // Create an instance of a customer
    public class Customer
    {
        private string m_Name;
        private string m_PhoneNumber;
        private Garage.eCarStatus m_CarStatus;
        private Vehicle m_CustomerVehicle;

        public Customer(string i_Name, string i_PhoneNumber, Garage.eCarStatus i_MaintenenceStatus, Vehicle i_Vehicle)
        {
            this.m_Name = i_Name;
            this.m_PhoneNumber = i_PhoneNumber;
            this.m_CarStatus = i_MaintenenceStatus;
            this.m_CustomerVehicle = i_Vehicle;
        }

        public string Name
        {
            get
            {
                return this.m_Name;
            }

            set
            {
                this.m_Name = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.m_PhoneNumber;
            }

            set
            {
                this.m_PhoneNumber = value;
            }
        }

        public Garage.eCarStatus Status
        {
            get
            {
                return this.m_CarStatus;
            }

            set
            {
                this.m_CarStatus = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this.m_CustomerVehicle.LicenseNumber;
            }
        }

        public Vehicle CustomerVehicle
        {
            get
            {
                return this.m_CustomerVehicle;
            }
        }
    }
}
