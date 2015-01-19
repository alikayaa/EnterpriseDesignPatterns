using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ForeignKeyMapping
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                KitapMapper _kitapMapper = new KitapMapper();
                Kitap _kitap = _kitapMapper.Find(1);
                kitap.Text = _kitap.Adi;
                yazar.Text = _kitap.Yazar.Adi;
            }
        }
    }
}