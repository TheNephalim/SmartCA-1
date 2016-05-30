using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Model
{
    public class MutableAddress
    {
        private string street;
        private string city;
        private string state;
        private string postalCode;

        public MutableAddress()
        {
        }

        public MutableAddress(Address address)
        {
            street = address.Street;
            city = address.City;
            state = address.State;
            postalCode = address.PostalCode;
        }

        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        public Address ToAddress()
        {
            return new Address(Street, City, State, PostalCode);
        }

        public override string ToString()
        {
            return this.ToAddress().ToString();
        }
    }
}
