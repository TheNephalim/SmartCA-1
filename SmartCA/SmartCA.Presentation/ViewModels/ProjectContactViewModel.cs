using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SmartCA.Application;
using SmartCA.Infrastructure.UI;
using SmartCA.Model;
using SmartCA.Model.Companies;
using SmartCA.Model.Contacts;
using SmartCA.Model.Projects;

namespace SmartCA.Presentation.ViewModels
{
    public class ProjectContactViewModel : AddressesViewModel
    {
        private static class Constants
        {
            public const string CurrentContactPropertyName = "CurrentContact";
        }

        private CollectionView contacts;
        private IList<ProjectContact> contactList;
        private ProjectContact currentContact;
        private CollectionView companies;
        private DelegateCommand saveCommand;
        private DelegateCommand newCommand;

        public ProjectContactViewModel() : this(null)
        {
        }

        public ProjectContactViewModel(IView view) : base(view)
        {
            contactList = UserSession.CurrentProject.Contacts;
            contacts = new CollectionView(contactList);
            currentContact = null;
            companies = new CollectionView(CompanyService.GetAllCompanies());
            this.saveCommand = new DelegateCommand(SaveCommandHandler);
            this.newCommand = new DelegateCommand(NewCommandHandler);
        }

        public CollectionView Contacts
        {
            get { return contacts; }
        }

        public ProjectContact CurrentContact
        {
            get { return currentContact; }
            set
            {
                if (this.currentContact != value)
                {
                    this.currentContact = value;
                    this.OnPropertyChanged(Constants.CurrentContactPropertyName);
                    this.saveCommand.IsEnabled = (this.currentContact != null);
                    this.PopulateAddresses();
                }
            }
        }

        public CollectionView Companies
        {
            get { return companies; }
        }

        public DelegateCommand SaveCommand {
            get { return saveCommand; }
        }

        public DelegateCommand NewCommand {
            get { return newCommand; }
        }

        private void SaveCommandHandler(object sender, EventArgs e)
        {
            this.currentContact.Contact.Addresses.Clear();
            foreach (MutableAddress address in this.Addresses)
            {
                this.currentContact.Contact.Addresses.Add(address.ToAddress());
            }
            ProjectService.SaveProjectContact(this.currentContact);
        }

        private void NewCommandHandler(object sender, EventArgs e)
        {
            ProjectContact contact = new ProjectContact(UserSession.CurrentProject, null, new Contact(null, "{First Name}", "{Last Name}"));
            this.contactList.Add(contact);
            this.contacts.Refresh();
            this.contacts.MoveCurrentToLast();
        }

        protected override void PopulateAddresses()
        {
            this.Addresses.Clear();
            foreach (Address address in this.currentContact.Contact.Addresses)
            {
                this.Addresses.Add(new MutableAddress(address));
            }
            base.PopulateAddresses();
        }
    }
}
