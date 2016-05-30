using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure.EntityFactoryFramework;
using SmartCA.Model.Companies;

namespace SmartCA.Infrastructure.Repositories
{
    internal class CompanyFactory:IEntityFactory<Company>
    {
        internal static class FieldNames
        {
            public const string CompanyId = "CompanyId";
            public const string Name = "CompanyName";
            public const string ShortName = "CompanyShortName";
            public const string Phone = "Phone";
            public const string Fax = "Fax";
            public const string Url = "Url";
            public const string Remarks = "Remarks";
            public const string IsHeadquarters = "IsHeadquarters";
        }

        public Company BuildEntity(IDataReader reader)
        {
            Company company = new Company(reader[FieldNames.CompanyId]);
            company.Name = reader[FieldNames.Name].ToString();
            company.Abbreviation = reader[FieldNames.ShortName].ToString();
            company.PhoneNumber = reader[FieldNames.Phone].ToString();
            company.FaxNumber = reader[FieldNames.Fax].ToString();
            company.Url = reader[FieldNames.Url].ToString();
            company.Remarks = reader[FieldNames.Remarks].ToString();
            return company;
        }

        internal static bool IsHeadquartersAddress(IDataReader reader)
        {
            return DataHelper.GetBoolean(reader[FieldNames.IsHeadquarters]);
        }
    }
}
