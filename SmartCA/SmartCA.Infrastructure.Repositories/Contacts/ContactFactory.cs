using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure.EntityFactoryFramework;
using SmartCA.Model.Companies;
using SmartCA.Model.Contacts;

namespace SmartCA.Infrastructure.Repositories
{
    internal class ContactFactory: IEntityFactory<Contact>
    {
        public static class FieldNames
        {
            public const string ContactId = "ContactID";
            public const string CompanyId = "CompanyID";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
            public const string JobTitle = "JobTitle";
            public const string Email = "Email";
            public const string Phone = "Phone";
            public const string MobilePhone = "MobilePhone";
            public const string Fax = "Fax";
            public const string Remarks = "Remarks";
        }


        public Contact BuildEntity(IDataReader reader)
        {
            Contact contact = new Contact(reader[FieldNames.ContactId], reader[FieldNames.FirstName].ToString(), reader[FieldNames.LastName].ToString());
            contact.JobTitle = reader[FieldNames.JobTitle].ToString();
            contact.Email = reader[FieldNames.Email].ToString();
            contact.PhoneNumber = reader[FieldNames.Phone].ToString();
            contact.MobilePhoneNumber = reader[FieldNames.MobilePhone].ToString();
            contact.FaxNumber = reader[FieldNames.Fax].ToString();
            contact.Remarks = reader[FieldNames.Remarks].ToString();
            return contact;
        }
    }
}
