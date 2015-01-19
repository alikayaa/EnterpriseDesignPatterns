using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UnitOfWork
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSale_Click(object sender, EventArgs e)
        {
            Books book = new Books();
            book.Name = "Enterprise Arch.";
            book.Amount = 60;
            book.Type = 1;
            UnitOfWork uow = new UnitOfWork();
            uow.BookRepository.Insert(book);
            Session["Book"] = book;
            Session["uow"] = uow;
            Response.Redirect("Sales.aspx");
        }
    }
}