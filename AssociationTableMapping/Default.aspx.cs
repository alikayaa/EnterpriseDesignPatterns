using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssociationTableMapping
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=WINDOZE\SQLEXPRESS;Initial Catalog=DAI;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Musteri", conn);
                SqlDataAdapter _adapter = new SqlDataAdapter("SELECT * FROM MusteriUrun", conn);
                SqlDataAdapter __adapter = new SqlDataAdapter("SELECT * FROM Urun", conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Musteri");
                _adapter.Fill(ds, "MusteriUrun");
                __adapter.Fill(ds, "Urun");

                MusteriMapper _mapper = new MusteriMapper();
                _mapper.dsh.Data = ds;
                Musteri _musteri = _mapper.Find(1);
                musteri.Text = _musteri.Adi;
                urunler.DataTextField = "Adi";
                urunler.DataValueField = "Id";
                foreach (Urun item in _musteri.Urunler)
                {
                    urunler.Items.Add(item.Adi);
                }
            }
        }
    }
}