using SmartCA.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Model.Employees
{
    public class Employee : Person
    {
        private string jobTitle;

        public Employee(object key)
            :this(key, string.Empty, string.Empty)
        {
        }

        public Employee(object key, string firstName, string lastName)
            :base(key, firstName, lastName)
        {
            this.jobTitle = string.Empty;
        }

        public string JobTitle
        {
            get { return jobTitle; }
            set { jobTitle = value; }
        }
    }
}
