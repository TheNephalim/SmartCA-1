using System.Collections.Generic;
using SmartCA.Model.Companies;

namespace SmartCA.Model.Contacts
{
    public class Contact :Person
    {
        private string jobTitle;
        private string email;
        private string phoneNumber;
        private string mobilePhoneNumber;
        private string faxNumber;
        private string remarks;
        private Company currentCompany;
        private IList<Address> addresses;

        public Contact():this(null)
        {
        }

        public Contact(object key):this(key, null, null)
        {
        }

        public Contact(object key, string firstName, string lastName) : base(key, firstName, lastName)
        {
            this.JobTitle = string.Empty;
            this.Email = string.Empty;
            this.PhoneNumber = string.Empty;
            this.MobilePhoneNumber = string.Empty;
            this.FaxNumber = string.Empty;
            this.Remarks = string.Empty;
            this.CurrentCompany = null;
            this.addresses = new List<Address>();
        }

        public string JobTitle
        {
            get { return jobTitle; }
            set { jobTitle = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string MobilePhoneNumber
        {
            get { return mobilePhoneNumber; }
            set { mobilePhoneNumber = value; }
        }

        public string FaxNumber
        {
            get { return faxNumber; }
            set { faxNumber = value; }
        }

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        public Company CurrentCompany
        {
            get { return currentCompany; }
            set { currentCompany = value; }
        }

        public IList<Address> Addresses
        {
            get { return addresses; }
        }
    }
}
