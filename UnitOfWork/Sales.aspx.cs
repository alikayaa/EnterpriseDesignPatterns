using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UnitOfWork
{
    public partial class Sales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Books salesBook = (Books)Session["Book"];
                fiyat.Text = salesBook.Amount.ToString();
                tip.Text = salesBook.Type == 1 ? "Bilgisayar" : "Roman";
            }
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            // Kitap nesnesi oluştur
            Books book = (Books)Session["book"];
            // Unit of Work nesnesi oluştur
            UnitOfWork uow = (UnitOfWork)Session["uow"];
            // Kitap vitrin satış nesnesi oluştur
            BookSales sales = new BookSales();
            // Fiyatı ayarla            
            sales.Amount = book.Amount;
            // Satış zamanı ayarla.            
            sales.SalesTime = DateTime.Now;
            // Kitap Id             
            sales.BookId = book.Id;
            // Kitap vitrin satışı repository si ile ekle            
            uow.BookSalesRepository.Insert(sales);
            // Unit of Work üzerinden değişiklikleri uygula            
            uow.Save();
            // Teşekkürler
            Response.Redirect("Thanks.aspx");
        }
    }
}