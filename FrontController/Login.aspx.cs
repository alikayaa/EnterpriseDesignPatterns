using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontController
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName= txtKullaniciAdi.Text;
            string password = txtSifre.Text;
            //burada kullanıcı adı ve şifre değerleriyle veri tabanına gidildiği düşünülür.
            //veri tabanından ilgili kullanıcının admin yetkisine mi sahip olduğu kontrol edilir.

            //yapılan controller sonucu kullanıcımızın admin çıktığını düşünelim.
            HttpContext.Current.Application["commandName"] = "AdminPageCommand";
            //daix uzantılı olan istekleri web config' de belirlediğimiz üzere
            //front controller' ımıza düşürüyoruz.
            //front controllerımızda gelen parametreye göre ilgili sayfaya yönlendirmeyi yapıyor.
            Response.Redirect("/Dai.daix");
        }
    }
}