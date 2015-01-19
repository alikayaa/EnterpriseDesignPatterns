using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowDataGateway
{
    //bu sınıfın domain katmanında olduğunu düşünelim
    public class Customer
    {
        private CustomerGateway customerGateway;
        private CustomerFinder customerFinder;

        public Customer(CustomerGateway customerGateway)
        {
            this.customerGateway = customerGateway;
        }

        public Customer(CustomerGateway customerGateway, CustomerFinder customerFinder)
        {
            this.customerGateway = customerGateway;
            this.customerFinder = customerFinder;
        }

        //buralarda yazacağımız metodlarda data katmanında tanımlı olan CustomerGateway ve CustomerFinder
        //sınıfları kullanılarak, iş kurallarımızı yazabiliriz. Örneğin, silmeden önce şunu kontrol et gibi.

    }
}
