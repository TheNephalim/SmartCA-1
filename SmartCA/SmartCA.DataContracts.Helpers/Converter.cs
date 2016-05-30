using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DataContracts;
using SmartCA.Infrastructure.DomainBase;
using SmartCA.Model;
using SmartCA.Model.Companies;

namespace SmartCA.DataContracts.Helpers
{
    public static class Converter
    {
        public static IEntity ToEntity(ContractBase contract)
        {
            string methodName = string.Format("To{0}", contract.GetType().Name.Replace("Contract", ""));
            MethodInfo method = typeof (Converter).GetMethod(methodName);
            return method.Invoke(null, new object[] {contract}) as IEntity;
        }

        public static ContractBase ToContract(IEntity entity)
        {
            string methodName = string.Format("To{0}Contract", entity.GetType().Name);
            MethodInfo method = typeof (Converter).GetMethod(methodName);
            return method.Invoke(null, new object[] {entity}) as ContractBase;
        }

        public static CompanyContract ToCompanyContract(Company company)
        {
            CompanyContract contract = new CompanyContract();
            contract.Key = company.Key;
            contract.Abbreviation = company.Abbreviation;
            foreach (Address address in company.Addresses)
            {
                contract.Addresses.Add(Converter.ToAddressContract(address));
            }
            contract.FaxNumber = company.FaxNumber;
            contract.HeadquartersAddress = Converter.ToAddressContract(company.HeadquartersAddress);
            contract.Name = company.Name;
            contract.PhoneNumber = company.PhoneNumber;
            contract.Remarks = company.Remarks;
            contract.Url = company.Url;
            return contract;
        }

        public static Company ToCompany(CompanyContract contract)
        {
            Company company = new Company(contract.Key);
            company.Abbreviation = contract.Abbreviation;
            foreach (AddressContract address in contract.Addresses)
            {
                company.Addresses.Add(Converter.ToAddress(address));
            }
            company.FaxNumber = contract.FaxNumber;
            company.HeadquartersAddress = Converter.ToAddress(contract.HeadquartersAddress);
            company.Name = contract.Name;
            company.PhoneNumber = contract.PhoneNumber;
            company.Remarks = contract.Remarks;
            company.Url = contract.Url;
            return company;
        }

        private static Address ToAddress(AddressContract address)
        {
            throw new NotImplementedException();
        }

        private static AddressContract ToAddressContract(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
