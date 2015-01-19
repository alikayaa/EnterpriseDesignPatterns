using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontController
{
    public interface ICommand
    {
        void Execute(HttpContext context);
    }
}