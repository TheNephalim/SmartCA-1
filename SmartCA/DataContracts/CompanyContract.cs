using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace SmartCA.DataContracts
{
    [Serializable]
    public class CompanyContract : ContractBase
    {
            private string name;
            private string abbreviation;
            private AddressContract headquartersAddress;
            private List<AddressContract> addresses;
            private string phoneNumber;
            private string faxNumber;
            private string url;
            private string remarks;

            public CompanyContract()
            {
                this.name = string.Empty;
                this.abbreviation = string.Empty;
                this.headquartersAddress = null;
                this.addresses = new List<AddressContract>();
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

            public AddressContract HeadquartersAddress
            {
                get { return headquartersAddress; }
                set { this.headquartersAddress = value; }
            }

            public IList<AddressContract> Addresses
            {
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
