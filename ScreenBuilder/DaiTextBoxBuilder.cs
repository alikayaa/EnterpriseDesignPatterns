using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using ScreenEntity;

namespace ScreenBuilder
{
    //DaiTextBox kontrol tipi için DaiTextBoxBuilder sınıfını
    //ana sınıfımızdan türetiriz. İçerisinde de yeni bir TextBox
    //oluşturup Id değerini ilgili name özelliğine atarız.
    public class DaiTextBoxBuilder:DaiControlBuilderBase
    {
        internal override Control Build(DaiControlBase control)
        {
            TextBox t = new TextBox();
            t.ID = control.Name;
            return t;
        }
    }
}
