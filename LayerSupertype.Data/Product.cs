using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayerSupertype.Data
{
    public class Product:LayerSupertype
    {
        public int ProductName { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
    }
}
