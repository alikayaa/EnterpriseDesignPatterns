using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmbeddedValue
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IlanMapper _mapper = new IlanMapper();
                Ilan _ilan = _mapper.Find(1);
                ilanAd.Text = _ilan.IlanAdi;
                tarih.Text = _ilan.IlanSuresi.ToString();
                fiyat.Text = _ilan.IlanFiyat.ToString();
            }
        }
    }
}