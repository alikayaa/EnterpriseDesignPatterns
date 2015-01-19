using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DAI.Orm;
using DAI.Orm.Context;
using DAI.Orm.Attributes;
using UnitOfWork;
namespace DAI.Orm.Context
{
    public class AutoContext : BaseContext
    {
        public DAIList<Books> Books = new DAIList<Books>();
        public DAIList<BookSales> BookSales = new DAIList<BookSales>();
    }

}


