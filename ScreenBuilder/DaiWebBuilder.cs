using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using ScreenEntity;

namespace ScreenBuilder
{
    //bu sınıfta web için otomatik ekran üretme yapılacaktır.
    //parametre olarak gelen xml' deki veriye göre, DaiForm içerisindeki
    //kontrollerle birlikte oluşturulur. Daha sonra içerisindeki kontroller
    //for la dönülüp, her birini builder nesnesi sırayla oluşturulup build edilip
    //PlacaHolder nesnemizin içerisine doldurulur.
    //en sonunda geriye bu PlaceHolder nesnesi dönülür.
    public class DaiWebBuilder
    {
        public static PlaceHolder Build(string xmlPath)
        {
            DaiForm frm = DaiScreenContainer.Get(xmlPath);
            PlaceHolder plc = new PlaceHolder();
            foreach (DaiControlBase control in frm.Controls)
            {
                DaiControlBuilderBase builder = DaiControlBuilderFactory.GetBuilder(control);
                plc.Controls.Add(builder.Build(control));
            }
            return plc;
        }
    }
}
