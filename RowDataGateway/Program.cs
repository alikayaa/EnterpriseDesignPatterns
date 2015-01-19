using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowDataGateway
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerGateway eklenecek = new CustomerGateway();
            eklenecek.Country = "Türkiye";
            eklenecek.DateOfBorn = Convert.ToDateTime("1990-03-28");
            eklenecek.FirstName = "Hasan";
            eklenecek.LastName = "Mehmet";
            int customerId=eklenecek.AddCustomer();

            CustomerGateway guncellenecek = new CustomerGateway();
            guncellenecek.Id = customerId;
            guncellenecek.Country = "Türkiye";
            guncellenecek.DateOfBorn = Convert.ToDateTime("1989-03-28");
            guncellenecek.FirstName = "Hasan";
            guncellenecek.LastName = "Mehmet";
            guncellenecek.UpdateCustomer();

            CustomerGateway silinecek = new CustomerGateway();
            silinecek.Id = customerId;
            silinecek.RemoveCustomer();

            CustomerGateway singleRow = new CustomerGateway();
            singleRow.Id = 5;
            CustomerFinder finder = new CustomerFinder(singleRow);
            finder.GetCustomerbyId();
        }
    }
}
