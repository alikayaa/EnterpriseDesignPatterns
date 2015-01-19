using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAI.Orm.Provider;
using DAI.Orm;
namespace UnitOfWork
{
    // Kod tekrar atılırken, SQLServerProvider’dan yine aşağıdaki fonksiyonlar alınacak sadece. 
    // Add, Delete, Update
    //kod örneğinde ORM kullanılıyor
    public class Repository<T>:SQLServerProvider<T> where T:class ,IModel
    {

    }
}