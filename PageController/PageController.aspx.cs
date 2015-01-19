using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PageController
{
    public partial class Customer : TemplateView
    {
        protected override void SubPageLoadEvent(object sender, EventArgs e)
        {
            lblCodeBehind.Text = "Code behind' dan geldi";
            //burada Request nesnesinin içinden gelen parametreler valide edilebilir.
            //gerekli veri tabanı işlemleri yapılabilir.
        }
    }
}