using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using WiredBrainCoffee.CustomersApp.Model;


namespace WiredBrainCoffee.CustomersApp.Controls
{
    [ContentProperty(Name = nameof(Customer))]
    public sealed partial class CustomerDetailControl : UserControl
    {
        public static readonly DependencyProperty CustomerProperty =
            DependencyProperty.Register("Customer", typeof(Customer), typeof(CustomerDetailControl), new PropertyMetadata(null));

        public CustomerDetailControl()
        {
            this.InitializeComponent();
        }

        public Customer Customer
        {
            get { return (Customer)GetValue(CustomerProperty); }
            set { SetValue(CustomerProperty, value); }
        }


    }
}


//before twoway binding from customers details xaml file

        //public static readonly DependencyProperty CustomerProperty =
            //DependencyProperty.Register("Customer", typeof(Customer), typeof(CustomerDetailControl), new PropertyMetadata(null, CustomerChangeCallback));

        //private static void CustomerChangeCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is CustomerDetailControl customerDetailControl)
        //    {
        //        var customer = e.NewValue as Customer;

        //        customerDetailControl.txtFirstName.Text = customerDetailControl.Customer?.FirstName ?? "";
        //        customerDetailControl.txtLastName.Text = customer?.LastName ?? "";
        //        customerDetailControl.cboxIsDev.IsChecked = customer?.IsDeveloper;
        //    }
        //}


//before binding from the main page xaml file
        //public Customer Customer
        //{
        //    get { return _customer; }
        //    set { 
        //        _customer = value;

        //        txtFirstName.Text = _customer?.FirstName ?? "";
        //        txtLastName.Text = _customer?.LastName ?? "";
        //        cboxIsDev.IsChecked = _customer?.IsDeveloper;
        //    }
        //}



        //private void txtFirstName_TextChanged(object sender, TextChangedEventArgs e) => UpdateCustomer();

        //private void txtLastName_TextChanged(object sender, TextChangedEventArgs e) => UpdateCustomer();

        //private void cboxIsDev_Changed(object sender, RoutedEventArgs e) => UpdateCustomer();


        //private void UpdateCustomer()
        //{            
        //    if (Customer != null)
        //    {
        //        Customer.FirstName = txtFirstName.Text;
        //        Customer.LastName = txtLastName.Text;
        //        Customer.IsDeveloper = cboxIsDev.IsChecked.GetValueOrDefault();
        //    }
        //}