using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class CustomerModel
    {
        public string GetCustomerNameByTcNo(long tcNo)
        { 
            //burada sanki veri tabanına gitmiş gibi davranıyoruz.
            return "Müşteri - " + tcNo.ToString(); ;
        }


    }
}
