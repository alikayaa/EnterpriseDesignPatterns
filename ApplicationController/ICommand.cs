using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApplicationController
{
    public interface ICommand
    {
        bool Execute(HttpRequest request);
    }
}
