using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ApplicationController;

namespace WebApplicationAppController
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ApplicationController.ApplicationController appCont = new ApplicationController.ApplicationController();

            //birinci parametrede hangi komutun çalıştırılması gerektiği,
            //ikinci parametrede başarılı olursa ne yapılması gerektiği,
            //üçüncü parametrede başarısız olursa ne yapılması gerektiği,
            //son parametrede ise input parametrelerimizi yolluyoruz.
            appCont.Raise(new AuthenticationCommand(),()=> Response.Redirect("/CustomerList.aspx"), ()=>Response.Redirect("InvalidAuthentication.aspx"), Request);
        }
    }
}