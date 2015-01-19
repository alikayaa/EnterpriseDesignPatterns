using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontController
{
    public class UnKnownCommand:ICommand
    {
        public void Execute(HttpContext context)
        {
            
        }
    }
}