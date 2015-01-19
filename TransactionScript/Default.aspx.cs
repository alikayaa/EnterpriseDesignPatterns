using DAI.Orm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TransactionScript
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack){
                CalisanMaasiHesapla();
            }                        
        }
        // Çalışan ücretlerini hesapla
        public void CalisanMaasiHesapla()
        {
            // Orm db context nesnesi
            DbContext db = new DbContext();
            int _calisanSayisi = db.Calisan.ToList().Count;
            decimal _maas = db.Calisan.Sum(i => i.Sallery);
            // Sonucları UI'a ata.
            calisanSayisi.Text = _calisanSayisi.ToString();
            maas.Text = _maas.ToString();
        }
    }
}