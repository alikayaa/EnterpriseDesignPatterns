using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
    }
}