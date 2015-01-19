using DAI.Orm;
using DAI.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UnitOfWork
{
    // Kitap sınıfımız.
    public class Books :IModel
    {
        [AutoInc(1,1)]
        [PrimaryKeyAttr]
        public int Id { get; set; }
        [NVARCHAR(50)]
        public string Name { get; set; }
        [INT]
        public int Type { get; set; }
        [INT]
        public int Amount { get; set; }
    }
}