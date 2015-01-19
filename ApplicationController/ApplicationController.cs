using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApplicationController
{
    public class ApplicationController:IApplicationController
    {
        public void Raise(ICommand command, Action succeedCallBack, Action failedCallBack,HttpRequest request)
        {
            if (this.Execute(command,request))
                succeedCallBack();
            else
                failedCallBack();
        }

        public bool Execute(ICommand command,HttpRequest request)
        {
            return command.Execute(request);
        }

    }
}
