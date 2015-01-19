using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TableModule
{
    // Kitap Satışı Sınıfımız
    public class BookSales:TableModule
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
        public BookSales(DataSet ds)
            : base(ds, "BookSales")
        {

        }
        // Kitap Satışını Kayıt Altına Al.
        public void Insert(int bookId, int amount, DateTime date)
        {
            DataRow newRow = table.NewRow();
            newRow["BookId"] = bookId;
            newRow["Amount"] = amount;
            newRow["SalesTime"] = String.Format("{0:s}", date);
            table.Rows.Add(newRow);
        }
        // Toplam Hasılatı Yeniden Hesapla
        public int GetTotalSales()
        {
            int result = 0;

            foreach (DataRow item in table.Rows)
            {
                result += Convert.ToInt32(item["Amount"]);
            }

            return result;
        }
    }
}