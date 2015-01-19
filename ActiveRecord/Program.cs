using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer eklenecek = new Customer();
            eklenecek.Country = "Türkiye";
            eklenecek.DateOfBorn = Convert.ToDateTime("1990-03-28");
            eklenecek.FirstName = "Hasan";
            eklenecek.LastName = "Mehmet";
            int customerId = eklenecek.AddCustomer();

            Customer guncellenecek = new Customer();
            guncellenecek.Id = customerId;
            guncellenecek.Country = "Türkiye";
            guncellenecek.DateOfBorn = Convert.ToDateTime("1989-03-28");
            guncellenecek.FirstName = "Hasan";
            guncellenecek.LastName = "Mehmet";
            guncellenecek.UpdateCustomer();

            Customer silinecek = new Customer();
            silinecek.Id = customerId;
            silinecek.RemoveCustomer();

            Customer businessOperation = new Customer();
            int customerCount = businessOperation.GetCustomerCount();
            List<Customer> after1990 = businessOperation.GetCustomerBornAfterDate(new DateTime(1990,01,01));

        }
    }
}
