using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Model
{
    public class Address
    {
        private string street;
        private string city;
        private string state;
        private string postalCode;

        public Address(string street, string city, string state, string postalCode)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.postalCode = postalCode;
            Validate();
        }

        public string Street
        {
            get { return street; }
        }

        public string City
        {
            get { return city; }
        }

        public string State
        {
            get { return state; }
        }

        public string PostalCode
        {
            get { return postalCode; }
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(street)
                || string.IsNullOrWhiteSpace(city)
                || string.IsNullOrWhiteSpace(state)
                || string.IsNullOrWhiteSpace(postalCode))
            {
                throw  new InvalidOperationException("Invalid address.");
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(300);
            builder.Append(street);
            builder.Append("\r\n");
            builder.Append(city);
            builder.Append(", ");
            builder.Append(state);
            builder.Append(" ");
            builder.Append(postalCode);
            return builder.ToString();
        }
    }
}
