using DAI.Orm;
using DAI.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UnitOfWork
{
    // Kitap Satışı Sınıfımız
    public class BookSales:IModel
    {
        [AutoInc(1, 1)]
        [PrimaryKeyAttr]
        public int Id { get; set; }
        [DATETIME]
        public DateTime SalesTime { get; set; }
        [INT]
        public int Amount { get; set; }
        [INT]
        public int BookId { get; set; }
    }
}