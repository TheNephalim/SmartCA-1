using SmartCA.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Model
{
    public abstract class Person : EntityBase
    {
        private string firstName;
        private string lastName;
        private string initials;

        protected Person()
            : this(null)
        {
        }

        protected Person(object key)
            :this(key, string.Empty, string.Empty)
        {
        }

        protected Person(object key, string firstName, string lastName)
            : base(key)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.initials = string.Empty;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Initials
        {
            get { return initials; }
            set { initials = value; }
        }
    }
}
