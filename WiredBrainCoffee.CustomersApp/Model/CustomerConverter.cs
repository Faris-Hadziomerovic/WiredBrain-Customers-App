using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiredBrainCoffee.CustomersApp.Model
{
    public static class CustomerConverter
    {
        public static Customer CreateCustomerFromString(string input)
        {
            var attributes = input.Split(',');
            return new Customer { FirstName = attributes[0], LastName = attributes[1], IsDeveloper = bool.Parse(attributes[2]) };
        }
    }
}
