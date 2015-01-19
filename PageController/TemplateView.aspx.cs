using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PageController
{
    public partial class TemplateView : System.Web.UI.Page
    {
        protected Label lblKullaniciAdi;
        protected Label lblSayfaYuklenmeSuresi;

        virtual protected void SubPageLoadEvent(object sender, EventArgs e)
        { 
            //biz buraya bir şey yazmıyoruz ve alt sayfalardan istenirse ezilebilmesine
            //olanak tanıyoruz. Bu teknik aslında template view tasarım kalıbının işidir.
            //ancak asp.Net web Page zaten page controller alt yapısına sahip olduğundan
            //page controller'ı kullanırken genelde bu şekilde template view' le beraber
            //kullanarız.
        }
        //bir nevi template metod tasarım kalıbının bir örneği
        protected void Page_Load(object sender, EventArgs e)
        {
            lblKullaniciAdi.Text = Session["userName"].ToString();
            lblSayfaYuklenmeSuresi.Text = HttpContext.Current.Application["yuklenme"].ToString();
            SubPageLoadEvent(sender, e);
            
        }

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);

        }

    }
}