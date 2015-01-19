using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DependentMapping
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RehberMapper _mapper = new RehberMapper();
                Rehber _rehber = _mapper.Find(1);
                rehber.InnerText = _rehber.RehberAdi;
                foreach (Kisi item in _rehber.Kisiler)
                {
                    kisiler.Items.Add(string.Format("{0} - {1} ", item.Adi, item.Numarasi));
                }
            }
            
        }
    }
}