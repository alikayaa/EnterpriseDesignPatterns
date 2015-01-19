using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableDataGateway
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerGateway customerGateway = new CustomerGateway();
            int customerId = customerGateway.AddCustomer("Hasan","Mehmet",Convert.ToDateTime("1990-03-28"),"Türkiye");

            customerGateway.UpdateCustomer(customerId, "Hasan", "Mehmet", Convert.ToDateTime("1989-03-28"), "Türkiye");

            customerGateway.RemoveCustomer(customerId);

            customerGateway.GetCustomerbyId(5);
        }
    }
}
