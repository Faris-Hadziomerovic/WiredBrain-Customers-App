
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Popups;
using WiredBrainCoffee.CustomersApp.Base;
using WiredBrainCoffee.CustomersApp.DataProvider;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class MainViewModel : Observable
    {
        public ObservableCollection<Customer> Customers { get; }

        private Customer _selectedCustomer;

        public bool IsCustomerSelected => SelectedCustomer != null;

        private ICustomerDataProvider _customerDataProvider;


        public MainViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            Customers = new ObservableCollection<Customer>();
        }


        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsCustomerSelected));
                }
            }
        }

        public async Task LoadAsync()
        {
            Customers.Clear();

            var customers = await _customerDataProvider.LoadCustomersAsync();

            foreach (var customer in customers) { Customers.Add(customer); }            
            
        }

        public async Task SaveAsync() => await _customerDataProvider.SaveCustomersAsync(Customers);

        public void AddCustomer()
        {
            Customer customer = new Customer { FirstName = "new customer" };
            Customers.Add(customer);
            SelectedCustomer = customer;
        }

        public async void DeleteCustomer()
        {
            var customer = SelectedCustomer;

            if (customer != null)
            {
                Customers.Remove(customer);

                var messageDialog = new MessageDialog("Customer removed!");
                await messageDialog.ShowAsync();
            }
        }

    }
}
