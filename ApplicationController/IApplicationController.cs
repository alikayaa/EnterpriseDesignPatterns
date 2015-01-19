using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApplicationController
{
    public interface IApplicationController
    {
        bool Execute(ICommand command,HttpRequest request);
        void Raise(ICommand command, Action succeedCallBack, Action failedCallBack, HttpRequest request);
    }
}
