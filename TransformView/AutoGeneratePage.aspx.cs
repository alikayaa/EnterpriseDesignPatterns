using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ScreenBuilder;

namespace TransformView
{
    public partial class AutoGeneratePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreInit(EventArgs e)
        {
            plcForm.Controls.Add(DaiWebBuilder.Build(@"D:\Kitap\KitapYardımcıResimVeKod\Bölüm 5\Kodlar\TransformView\Screen\CustomerScreen.xml"));
            base.OnPreInit(e);
        }
    }
}