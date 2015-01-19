using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontController
{
    public class FrontController:IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            ICommand command=new UnKnownCommand();
            try 
	        {
                //aplication nesnesinin içerisinde bir adet command name nesnesinin olup olmadığı kontrol edilir.
                if (context.Application["commandName"] != null)
                {
                    command = (ICommand)Activator.CreateInstance(Type.GetType("FrontController."+context.Application["commandName"].ToString()));
                    command.Execute(context);
                }
	        }
	        catch
	        {
	        }
        }
    }
}