using ConcreteTableInheritance.Mapper;
using ConcreteTableInheritance.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConcreteTableInheritance
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dai.Visible = false;
                SqlConnection conn = new SqlConnection(@"Data Source=WINDOZE\SQLEXPRESS;Initial Catalog=DAI;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Kategori", conn);
                SqlDataAdapter _adapter = new SqlDataAdapter("SELECT * FROM Computer", conn);
                SqlDataAdapter __adapter = new SqlDataAdapter("SELECT * FROM Electronic", conn);
                SqlDataAdapter ___adapter = new SqlDataAdapter("SELECT * FROM Movies", conn);
                SqlDataAdapter ____adapter = new SqlDataAdapter("SELECT * FROM Phone", conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Kategori");
                _adapter.Fill(ds, "Computer");
                __adapter.Fill(ds, "Electronic");
                ___adapter.Fill(ds, "Movies");
                ____adapter.Fill(ds, "Phone");
                Gateway gateway = new Gateway();
                dai.Visible = true;
                gateway.Data = ds;
                CategoryMapper mapper = new CategoryMapper(gateway);
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
               
                Category m;
                if (Id > 0)
                {
                    
                    m = mapper.Find(Id);
                    // Ad Tüm Entity ler için ortak.
                    adi.Text = m.Adi;
                    // Gelen entity phone ise özellikleri set et.
                    if (m is Phone)
                    {
                        fourG.Text = ((Phone)m).FourG;
                        EkranGenisligi.Text = ((Phone)m).EkranGenisligi;
                        Aciklama.Text = ((Phone)m).Aciklama;
                    }
                }

            }
        }
    }
}