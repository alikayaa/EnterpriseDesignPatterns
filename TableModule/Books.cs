using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TableModule
{
    // Kitap sınıfımız.
    public class Books : TableModule
    {
        // DataSet üzerinden Row alma.
        public DataRow this[int key]
        {
            get
            {
                string filter = string.Format("Id = {0}", key);
                return table.Select(filter)[0];
            }
        }
        // Dataset'i temel sınıf olan Table Module gönder.
        public Books(DataSet ds)
            : base(ds, "Books")
        {

        }
        // Ücret Hesaplama
        public int CalculateSale(int bookId)
        {
            // Seçili Kitabı bulmak
            DataRow bookRow = this[bookId];
            // Seçili kitabın fiyatını bulma
            int amount = (int)bookRow["Amount"];
            // Kitap satışı yapacak nesne
            BookSales bookSales = new BookSales(table.DataSet);
            // İndirim Uygula
            amount -= Discount((int)bookRow["Type"]);
            // Satışı kaydet
            bookSales.Insert(bookId, amount, DateTime.Now);    
            // Toplam Hasılatı Hesapla
            return bookSales.GetTotalSales();
        }
        // İndirim Kuralı
        public int Discount(int bookType)
        {
            int result = 0;
            if (bookType == (int)BookType.Computer)
                result = 10;
            if (bookType == (int)BookType.Electronics)
                result = 7;
            if (bookType == (int)BookType.Story)
                result = 5;
            return result;
        }

    }

    // Kitap Tipleri
    public enum BookType
    {
        Computer = 1,
        Story = 2,
        Electronics = 3
    }
}