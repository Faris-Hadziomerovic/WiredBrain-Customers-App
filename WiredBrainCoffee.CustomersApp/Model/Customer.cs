using Windows.Foundation.Metadata;
using WiredBrainCoffee.CustomersApp.Base;

namespace WiredBrainCoffee.CustomersApp.Model
{
    [CreateFromString(MethodName = "WiredBrainCoffee.CustomersApp.Model.CustomerConverter.CreateCustomerFromString")]
    public class Customer : Observable
    {
        private string firstName;
        private string lastName;
        private bool isDeveloper;
        public string FullName { get => firstName + " " + lastName;  }

        public string FirstName
        {
            get => firstName; 
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string LastName
        {
            get => lastName; 
            set
            {
                lastName = value;
                OnPropertyChanged(); //nameof(LastName)
                OnPropertyChanged(nameof(FullName));


            }
        }

        public bool IsDeveloper
        {
            get => isDeveloper; 
            set
            {
                isDeveloper = value;
                OnPropertyChanged(); // "IsDeveloper"
            }
        }

    }
}
