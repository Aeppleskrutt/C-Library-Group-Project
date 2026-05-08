using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_C__Group_Project
{
    class ErrorHandler
    {
        public bool CheckIfCustomerExists(List<Customer> customers, string customerID)
        {
            bool customerExists = false;
            foreach (Customer customer in customers)
            {
                if (customer.CustomerID == customerID)
                {
                    customerExists = true;
                    break;
                }
            }

            return customerExists;
        }   

    }
}
