using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SmartCA.Infrastructure;
using SmartCA.Infrastructure.EntityFactoryFramework;
using SmartCA.Model.Projects;

namespace SmartCA.Infrastructure.Repositories
{
    internal class ProjectFactory : IEntityFactory<Project>
    {
        internal static class FieldNames
        {
            public const string ProjectId = "ProjectID";
            public const string ProjectNumber = "ProjectNumber";
            public const string ProjectName = "ProjectName";
            public const string ProjectAddress = "Street";
            public const string ProjectCity = "City";
            public const string ProjectState = "State";
            public const string ProjectPostalCode = "PostalCode";
            public const string ConstructionAdministratorEmployeeId = "ConstructionAdministratorEmployeeID";
            public const string PrincipalEmployeeId = "PrincipalEmployeeID";
            public const string ContractDate = "ContractDate";
            public const string EstimatedStartDate = "EstimatedStartDate";
            public const string EstimatedCompletionDate = "EstimatedCompletionDate";
            public const string ActualCompletionDate = "ActualCompletionDate";
            public const string ContigencyAllowanceAmount = "ContigencyAllowanceAmount";
            public const string TestingAllowanceAmount = "TestingAllowanceAmount";
            public const string UtilityAllowanceAmount = "UtilityAllowanceAmount";
            public const string OriginalConstructionCost = "OriginalConstructionCost";
            public const string TotalSquareFeet = "TotalSquareFeet";
            public const string PercentComplete = "PercentComplete";
            public const string Remarks = "Remarks";
            public const string AeChangeOrderAmount = "AeChangeOrderAmount";
            public const string ContractReason = "ContractReason";
            public const string AgencyApplicationNumber = "AgencyApplicationNumber";
            public const string AgencyFileNumber = "AgencyFileNumber";
            public const string MarketSegmentId = "MarketSegmentID";
            public const string OwnerCompanyId = "OwnerCompanyID";
            public const string AllowanceTitle = "AllowanceTitle";
            public const string AllowanceAmount = "Amount";
            public const string ProjectContactId = "ProjectContactID";
            public const string ContactId = "ContactID";
            public const string OnFinalDistributionList = "OnFinalDistributionList";
        }

        public Project BuildEntity(IDataReader reader)
        {
            Project project = new Project(
                reader[FieldNames.ProjectId]
                , reader[FieldNames.ProjectNumber].ToString()
                , reader[FieldNames.ProjectName].ToString());
            project.Address = AddressFactory.BuildAddress(reader);

            return project;
        }

        public static Allowance BuildAllowance(IDataReader reader)
        {
            return new Allowance(
                reader[FieldNames.AllowanceTitle].ToString()
                , DataHelper.GetDecimal(reader[FieldNames.AllowanceAmount].ToString()));
        }
    }
}
