using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScreenEntity
{
    //bütün kontrollerimizin sarmalanacağı sınıfımıza örnek olarak 
    //sadece name özelliğini yerleştirdik. Sınıfımızın serilize edilebilir 
    //olması gerekmektedir. Serilize etme işlemi sırasında DaiTextBox taglarını
    //ayrı bir şekilde serilize etmesi için de yine attribute'ler ile tanıttık.
    [Serializable]
    [XmlInclude(typeof(DaiTextBox))]
    public abstract class DaiControlBase
    {
        public string Name { get; set; }
    }
}
