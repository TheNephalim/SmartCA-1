using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Model;

namespace SmartCA.Infrastructure.Repositories
{
    internal static class AddressFactory
    {
        internal static class FieldNames
        {
            public const string Street = "Street";
            public const string City = "City";
            public const string State = "State";
            public const string PostalCode = "PostalCode";
        }

        internal static Address BuildAddress(IDataReader reader)
        {
             return new Address(reader[FieldNames.Street].ToString(), reader[FieldNames.City].ToString(), reader[FieldNames.State].ToString(), reader[FieldNames.PostalCode].ToString());
        }
    }
}
