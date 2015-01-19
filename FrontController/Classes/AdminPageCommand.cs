using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontController
{
    public class AdminPageCommand:ICommand
    {
        public void Execute(HttpContext context)
        {
            context.Server.Transfer("/AdminPage.aspx");
        }
    }
}