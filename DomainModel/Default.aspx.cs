using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DomainModel
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                CalisanMaasiHesapla();
            }     
        }

        // Çalışan ücretlerini hesapla
        public void CalisanMaasiHesapla()
        {
            // Orm db context nesnesi
            DbContext db = new DbContext();
            // Hesaplama Yönetim Sınıfı. İçerisinde strateji desen vardır. 
            // Çalışan tipine göre hesaplamaya karar verir.
            CalculateManager _calculater = new CalculateManager();
            int _calisanSayisi = db.Calisan.ToList().Count;
            int _maas = 0;
            foreach (Calisan _calisan in db.Calisan.ToList())
            {
                _maas += _calculater.CalculateSummary(_calisan);
            }
            calisanSayisi.Text = _calisanSayisi.ToString();
            maas.Text = _maas.ToString();

        }
    }
}