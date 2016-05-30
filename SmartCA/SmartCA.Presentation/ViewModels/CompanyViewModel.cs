using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SmartCA.Infrastructure.UI;
using SmartCA.Model;
using SmartCA.Model.Companies;

namespace SmartCA.Presentation.ViewModels
{
    public class CompanyViewModel : AddressesViewModel
    {
        private static class Constants
        {
            public const string CurrentCompanyPropertyName = "CurrentCompany";
            public const string HeadquartersAddressPropertyName = "HeadquartersAddress";
        }

        private CollectionView companies;
        private IList<Company> companiesList;
        private Company currentCompany;
        private MutableAddress headquartersAddress;
        private DelegateCommand saveCommand;
        private DelegateCommand newCommand;

        public CompanyViewModel():this(null)
        {}

        public CompanyViewModel(IView view):base(view)
        {
            this.companiesList = CompanyService.GetAllCompanies();
            companies = new CollectionView(companiesList);
            CurrentCompany = null;
            headquartersAddress = null;
            saveCommand = new DelegateCommand(SaveCommandHandler);
            newCommand = new DelegateCommand(NewCommandHandler);
        }

        public CollectionView Companies
        {
            get { return companies; }
        }

        public Company CurrentCompany
        {
            get { return currentCompany; }
            set
            {
                if (currentCompany != value)
                {
                    currentCompany = value;
                    this.OnPropertyChanged(Constants.CurrentCompanyPropertyName);
                    this.saveCommand.IsEnabled = (this.currentCompany != null);
                    this.PopulateAddresses();
                    this.HeadquartersAddress = new MutableAddress(this.currentCompany.HeadquartersAddress);
                }
            }
        }

        public MutableAddress HeadquartersAddress
        {
            get { return headquartersAddress; }
            set
            {
                if(headquartersAddress != value)
                {
                    headquartersAddress = value;
                    this.OnPropertyChanged(Constants.HeadquartersAddressPropertyName);
                }
            }
        }

        public DelegateCommand NewCommand
        {
            get { return newCommand; }
        }

        public DelegateCommand SaveCommand
        {
            get { return saveCommand; }
        }

        private void SaveCommandHandler(object sender, EventArgs e)
        {
            this.currentCompany.Addresses.Clear();
            foreach (MutableAddress address in this.Addresses)
            {
                this.currentCompany.Addresses.Add(address.ToAddress());
            }
            this.currentCompany.HeadquartersAddress = this.headquartersAddress.ToAddress();
            CompanyService.SaveCompany(currentCompany);
        }

        private void NewCommandHandler(object sender, EventArgs e)
        {
            Company company = new Company();
            company.Name = "{Enter Company Name}";
            this.companiesList.Add(company);
            this.companies.Refresh();
            this.companies.MoveCurrentToLast();
        }

        protected override void PopulateAddresses()
        {
            if (currentCompany != null)
            {
                this.Addresses.Clear();
                foreach (Address address in currentCompany.Addresses)
                {
                    this.Addresses.Add(new MutableAddress(address));
                }

                base.PopulateAddresses();
            }
        }
    }
}
