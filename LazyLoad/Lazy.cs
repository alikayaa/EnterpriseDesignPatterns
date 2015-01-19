using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LazyLoad
{
    public class Lazy
    {
        public int CustomerID
        {
            get
            {
                if (CustomerID == null)
                    CustomerID = 3; // Burada veri tabanı bağlantısı kurulup Entity doldurulabilir.

                return CustomerID;
            }

            set
            {
                CustomerID = value;
            }
        }
       

    }
}