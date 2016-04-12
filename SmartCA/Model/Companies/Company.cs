using SmartCA.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Model.Companies
{
    public class Company : EntityBase
    {
        private string name;
        private string abbreviation;
        private Address address;

        public Company()
            :this(null)
        {
        }

        public Company(object key)
            : base(key)
        {
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

        public Address HeadquartersAddress
        {
            get { return address; }
            set { address = value; }
        }
    }
}
