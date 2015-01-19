using DAI.Orm;
using DAI.Orm.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitOfWork
{
    // Unit Of Work Sınıfı
    public class UnitOfWork
    {
        // Veri tabanı context'i
        private AutoContext _dbcontext = new AutoContext();
        // Kitap Repository'si
        public Repository<Books> BookRepository = new Repository<Books>();
        // Kitap Satışları Repository'si
        public Repository<BookSales> BookSalesRepository = new Repository<BookSales>();
        // Değişiklikleri Kaydet
        public void Save()
        {
            _dbcontext.SaveChanges();
        }
    }
}