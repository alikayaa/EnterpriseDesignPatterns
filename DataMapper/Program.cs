using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer cust = new Customer();
            cust.Id = 1;
            cust.FirstName = "Ahmet";
            cust.LastName = "Mehmet";
            cust.DateOfBorn = Convert.ToDateTime("1990-01-01");
            cust.Country = "Türkiye";

            CustomerDataMapper dataMapper = new CustomerDataMapper();
            dataMapper.Insert(cust);

            cust.Country = "Türkiye 2";
            dataMapper.Update(cust);

        }
    }
}
