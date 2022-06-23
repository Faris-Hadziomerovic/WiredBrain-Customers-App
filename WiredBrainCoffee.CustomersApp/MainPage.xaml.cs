using System;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WiredBrainCoffee.CustomersApp.Controls;
using WiredBrainCoffee.CustomersApp.DataProvider;
using WiredBrainCoffee.CustomersApp.Model;
using WiredBrainCoffee.CustomersApp.ViewModel;

namespace WiredBrainCoffee.CustomersApp
{
   
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; }

        public MainPage()
        {
            this.InitializeComponent();

            ViewModel = new MainViewModel(new CustomerDataProvider());
            this.DataContext = ViewModel;

            this.Loaded += MainPage_Loaded;
            App.Current.Suspending += App_Suspending;

            this.RequestedTheme = (App.Current.RequestedTheme == ApplicationTheme.Dark) ? ElementTheme.Dark : ElementTheme.Light;
            this.btnIconChangeTheme.Glyph = (App.Current.RequestedTheme == ApplicationTheme.Dark) ? "\xE708" : "\xE706";
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e) => await ViewModel.LoadAsync();

        private async void App_Suspending(object sender, Windows.ApplicationModel.SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            await ViewModel.SaveAsync();

            deferral.Complete();
        }
        
        private void ButtonMove_Click(object sender, RoutedEventArgs e)
        {
            //int column = (int) customerListGrid.GetValue(Grid.ColumnProperty);
            int column = Grid.GetColumn(customerListGrid);

            int newColumn = (column == 0) ? 2 : 0;

            //customerListGrid.SetValue(Grid.ColumnProperty, newColumn);
            Grid.SetColumn(customerListGrid, newColumn);

            moveSymbolIcon.Symbol = (newColumn == 2) ? Symbol.Back : Symbol.Forward;

            //if (newColumn == 2)
            //    moveSymbolIcon.SetValue(SymbolIcon.SymbolProperty, Symbol.Back);
            //else
            //    moveSymbolIcon.SetValue(SymbolIcon.SymbolProperty, Symbol.Forward);

        }

        private void ButtonChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            if (this.RequestedTheme == ElementTheme.Light)
            {
                this.RequestedTheme = ElementTheme.Dark;
                btnIconChangeTheme.Glyph = "\xE708";
            }
            else
            {
                this.RequestedTheme = ElementTheme.Light;
                btnIconChangeTheme.Glyph = "\xE706";
            }
        }
    }
}



//private void customerListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
//{
//    //var customer = e.AddedItems[0] as Customer;

//    var customer = customerListView.SelectedItem as Customer;
//    CustomerDetailControl.Customer = customer;

//    //txtFirstName.Text = customer?.FirstName ?? "";
//    //txtLastName.Text = customer?.LastName ?? "";
//    //cboxIsDev.IsChecked = customer?.IsDeveloper;
//}




//private void txtFirstName_TextChanged(object sender, TextChangedEventArgs e) => UpdateCustomer();
//private void txtLastName_TextChanged(object sender, TextChangedEventArgs e) => UpdateCustomer();
//private void cboxIsDev_Changed(object sender, RoutedEventArgs e) => UpdateCustomer();
//private void UpdateCustomer()
//{
//    var customer = customerListView.SelectedItem as Customer;

//    if (customer != null)
//    {
//        customer.FirstName = txtFirstName.Text;
//        customer.LastName = txtLastName.Text;
//        customer.IsDeveloper = cboxIsDev.IsChecked.GetValueOrDefault();
//    }
//}