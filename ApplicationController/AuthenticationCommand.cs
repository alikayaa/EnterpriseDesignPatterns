using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApplicationController
{
    public class AuthenticationCommand:ICommand
    {
        public bool Execute(HttpRequest request)
        {
            //burada request nesnesinin içisinden ilgili parametreleri alıp
            //business katmanına gönderdiğini ve işlem yaptığını ve 
            //sonucun başarılı olduğunu düşünün
            return true;
        }
    }
}
