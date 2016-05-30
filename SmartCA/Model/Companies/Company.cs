using SmartCA.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Model.Companies
{
    public class Company : EntityBase
    {
        private string name;
        private string abbreviation;
        private Address headquartersAddress;
        private List<Address> addresses;
        private string phoneNumber;
        private string faxNumber;
        private string url;
        private string remarks;

        public Company()
            :this(null)
        {
        }

        public Company(object key)
            : base(key)
        {
            this.name = string.Empty;
            this.abbreviation = string.Empty;
            this.headquartersAddress = null;
            this.addresses = new List<Address>();
            this.PhoneNumber = string.Empty;
            this.FaxNumber = string.Empty;
            this.Url = string.Empty;
            this.Remarks = string.Empty;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Abbreviation
        {
            get { return abbreviation; }
            set { abbreviation = value; }
        }

        public Address HeadquartersAddress
        {
            get { return headquartersAddress; }
            set {
                if (this.headquartersAddress != value)
                {
                    this.headquartersAddress = value;
                    if (!this.addresses.Contains(value))
                    {
                        this.addresses.Add(value);
                    }
                }
            }
        }

        public IList<Address> Addresses {
            get { return this.addresses; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string FaxNumber
        {
            get { return faxNumber; }
            set { faxNumber = value; }
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
    }
}
