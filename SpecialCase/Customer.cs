using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialCase
{
    public class Customer
    {
        private int _customerId;
        //virtual tanımlanıyor ki alt sınıflar istediği gibi ezebilsin.
        public virtual int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        private string _customerName;
        //virtual tanımlanıyor ki alt sınıflar istediği gibi ezebilsin.
        public virtual string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        //virtual tanımlanıyor ki alt sınıflar istediği gibi ezebilsin.
        public virtual List<Order> GetOrders()
        { 
            //burada ilgili customer ın siparişleri çekilecekmiş 
            //gibi düşünürüz.
            List<Order> orders = new List<Order>();
            Order order1 = new Order() { Count = 2, ProductId = 2 };

            Order order2 = new Order() { Count = 4, ProductId = 1 };
            Order order3 = new Order() { Count = 5, ProductId = 21 };
            orders.Add(order1);
            orders.Add(order2);
            orders.Add(order3);

            return orders;
        }

        public override string ToString()
        {
            string result = "CustomerId: " + CustomerId + "\nCustomer Name: " + CustomerName + "\n";
            result += "Orders => \n";
            foreach (var order in GetOrders())
            {
                result += "\tProduct Id:" + order.ProductId;
                result += "\n\tCount: " + order.Count;
                result += "\n\n";
            }
            return result;
        }
    }
}
