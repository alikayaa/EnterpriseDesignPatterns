using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialCase
{
    //Özel bir durum olan tanınmayan müşteri nesnesi için
    //sınıf oluşturuyoruz. Bu sayede null kontrolü yapmaktan
    //kurtulacağız.
    public class UnknownCustomer:Customer
    {
        public override int CustomerId
        {
            get
            {
                return 0;
            }
            set { }
        }

        public override string CustomerName
        {
            get
            {
                return "Misafir müşteri";
            }
            set { }
        }

        public override List<Order> GetOrders()
        {
            return new List<Order>();
        }
    }
}
