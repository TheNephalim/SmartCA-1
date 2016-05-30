using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure.UI;
using SmartCA.Model;
using SmartCA.Presentation.UI;

namespace SmartCA.Presentation.ViewModels
{
    public abstract class AddressesViewModel : ViewModel
    {
        private static class Constants
        {
            public const string AddressesPropertyName = "Addresses";
        }

        private BindingList<MutableAddress> addresses;
        private DelegateCommand deleteAddressCommand;

        protected AddressesViewModel() : this(null)
        {
        }

        protected AddressesViewModel(IView view) : base(view)
        {
            addresses = new BindingList<MutableAddress>();
            deleteAddressCommand = new DelegateCommand(DeleteAddressCommandHandler);
        }

        public BindingList<MutableAddress> Addresses
        {
            get { return addresses; }
        }


        public DelegateCommand DeleteAddressCommand
        {
            get { return deleteAddressCommand; }
        }

        private void DeleteAddressCommandHandler(object sender, DelegateCommandEventArgs e)
        {
            MutableAddress address = e.Parameter as MutableAddress;
            if (address != null)
            {
                this.addresses.Remove(address);
            }
        }

        protected virtual void PopulateAddresses()
        {
            OnPropertyChanged(Constants.AddressesPropertyName);
        }
    }
}
