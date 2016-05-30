using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure.DomainBase;
using SmartCA.Model.Companies;
using SmartCA.Model.Contacts;

namespace SmartCA.Model.Projects
{
    public class ProjectContact:EntityBase
    {
        private Project project;
        private bool onFinalDistributionList;
        private Contact contact;

        public ProjectContact(Project project, object key, Contact contact) : base(key)
        {
            this.project = project;
            this.contact = contact;
            this.onFinalDistributionList = false;
        }

        public Project Project
        {
            get { return project; }
        }

        public bool OnFinalDistributionList
        {
            get { return onFinalDistributionList; }
            set { onFinalDistributionList = value; }
        }

        public Contact Contact
        {
            get { return contact; }
        }
    }
}
