using SmartCA.Infrastructure.DomainBase;
using SmartCA.Model.Companies;
using SmartCA.Model.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Model.Projects
{
    public class Project : EntityBase
    {
        private string number;
        private string name;
        private Address address;
        private Company owner;
        private DateTime? contractDate;
        private DateTime? estimatedStartDate;
        private DateTime? estimatedCompletionDate;
        private DateTime? actualCompletionDate;
        private decimal contigencyAllowanceAmount;
        private decimal testingAllowanceAmount;
        private decimal utilityAllowanceAmount;
        private decimal originalConstructionCost;
        private int totalSquareFeet;
        private int percentComplete;
        private string remarks;
        private decimal aeChangeOrderAmount;
        private string contractReason;
        private string agencyApplicationNumber;
        private string agencyFileNumber;
        private MarketSegment segment;
        
        private Employee constructionAdministrator;
        private Employee principalInCharge;
        private List<Allowance> allowances;
        public List<Contract> Contracts { get; private set; }

        public Project(string number, string name)
            :this(null, name, number)
        {
            this.number = number;
            this.name = name;
        }

        public Project(object key, string number, string name)
            :base(key)
        {
            this.number = number;
            this.name = name;
            this.address = null;
            this.owner = new Company();
            constructionAdministrator = null;
            principalInCharge = null;
            ContractDate = null;
            EstimatedStartDate = null;
            EstimatedCompletionDate = null;
            ActualCompletionDate = null;
            ContigencyAllowanceAmount = 0;
            TestingAllowanceAmount = 0;
            UtilityAllowanceAmount = 0;
            OriginalConstructionCost = 0;
            TotalSquareFeet = 0;
            PercentComplete = 0;
            Remarks = string.Empty;
            AeChangeOrderAmount = 0;
            ContractReason = string.Empty;
            AgencyApplicationNumber = string.Empty;
            AgencyFileNumber = string.Empty;
            Segment = null;
            allowances = new List<Allowance>();
            Contracts = new List<Contract>();
        }

        public string Number {
            get { return this.number; }
        }

        public string Name {
            get { return this.name; }
        }

        public Address Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public Company Owner {
            get { return owner; }
            set { owner = value; }
        }

        public Employee ConstructionAdministrator
        {
            get { return constructionAdministrator; }
            set { constructionAdministrator = value; }
        }

        public Employee PrincipalInCharge
        {
            get { return principalInCharge; }
            set { principalInCharge = value; }
        }

        public DateTime? ContractDate
        {
            get { return contractDate; }
            set { contractDate = value; }
        }

        public DateTime? EstimatedStartDate
        {
            get { return estimatedStartDate; }
            set { estimatedStartDate = value; }
        }

        public DateTime? EstimatedCompletionDate
        {
            get { return estimatedCompletionDate; }
            set { estimatedCompletionDate = value; }
        }

        public DateTime? ActualCompletionDate
        {
            get { return actualCompletionDate; }
            set { actualCompletionDate = value; }
        }

        public decimal ContigencyAllowanceAmount
        {
            get { return contigencyAllowanceAmount; }
            set { contigencyAllowanceAmount = value; }
        }

        public decimal TestingAllowanceAmount
        {
            get { return testingAllowanceAmount; }
            set { testingAllowanceAmount = value; }
        }

        public decimal UtilityAllowanceAmount
        {
            get { return utilityAllowanceAmount; }
            set { utilityAllowanceAmount = value; }
        }

        public decimal OriginalConstructionCost
        {
            get { return originalConstructionCost; }
            set { originalConstructionCost = value; }
        }

        public int TotalSquareFeet
        {
            get { return totalSquareFeet; }
            set { totalSquareFeet = value; }
        }

        public int PercentComplete
        {
            get { return percentComplete; }
            set { percentComplete = value; }
        }

        public string Remarks
        {
            get { return remarks; }
            private set { remarks = value; }
        }

        public decimal AeChangeOrderAmount
        {
            get { return aeChangeOrderAmount; }
            set { aeChangeOrderAmount = value; }
        }

        public string ContractReason
        {
            get { return contractReason; }
            set { contractReason = value; }
        }

        public string AgencyApplicationNumber
        {
            get { return agencyApplicationNumber; }
            set { agencyApplicationNumber = value; }
        }

        public string AgencyFileNumber
        {
            get { return agencyFileNumber; }
            set { agencyFileNumber = value; }
        }

        public MarketSegment Segment
        {
            get { return segment; }
            set { segment = value; }
        }

        public List<Allowance> Allowances
        {
            get { return allowances; }
            set { allowances = value; }
        }

    }
}
