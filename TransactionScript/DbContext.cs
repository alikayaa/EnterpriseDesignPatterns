using DAI.Orm.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionScript
{
    public class DbContext:BaseContext
    {
        public DAIList<Calisan> Calisan = new DAIList<Calisan>();
    }
}