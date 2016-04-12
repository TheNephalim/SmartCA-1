using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure.DomainBase;
using SmartCA.Model.Companies;

namespace SmartCA.Model.Projects
{
    public class Contract : EntityBase
    {
        private decimal contractAmount;
        private Company contractor;
        private string bidPackageNumber;
        private string scopeOfWork;
        private DateTime? contractDate;
        private DateTime? noticeToProceedDate;

        public Contract() : this(null)
        {
        }

        public Contract(object key) :base(key)
        {
            contractor = new Company();
            scopeOfWork = string.Empty;
            bidPackageNumber = string.Empty;
            contractAmount = 0;
        }

        public Company Contractor
        {
            get { return contractor; }
            set { contractor = value; }
        }

        public string ScopeOfWork
        {
            get { return scopeOfWork; }
            set { scopeOfWork = value; }
        }

        public string BidPackageNumber
        {
            get { return bidPackageNumber; }
            set { bidPackageNumber = value; }
        }

        public DateTime? ContractDate
        {
            get { return contractDate; }
            set { contractDate = value; }
        }

        public DateTime? NoticeToProceedDate
        {
            get { return noticeToProceedDate; }
            set { noticeToProceedDate = value; }
        }

        public decimal ContractAmount
        {
            get { return contractAmount; }
            set { contractAmount = value; }
        }
    }
}
