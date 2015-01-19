using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TableModule
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=WINDOZE\SQLEXPRESS;Initial Catalog=DAI;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Books", conn);
            SqlDataAdapter _adapter = new SqlDataAdapter("SELECT * FROM BookSales", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Books");
            _adapter.Fill(ds, "BookSales");
            Books _book = new Books(ds);
            totalAmount.Text =  _book.CalculateSale(Convert.ToInt32(ds.Tables[0].Rows[0]["Id"])).ToString();

            
        }
    }
}