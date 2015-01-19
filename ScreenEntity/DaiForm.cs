using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenEntity
{
    //Xmlden gelen veriyi aynen bu sınıfa convert 
    //edeceğiz. Dolayısıyla bu sınıfımızın içerisinde 
    //kontrollerimizin olması gerekmektedir.
    //Serializable olarak işaretlenmesi gerekmektedir.
    [Serializable]
    public class DaiForm
    {
        private DaiControls dai_Controls;
        public DaiControls Controls
        {
            get
            {
                if (dai_Controls == null)
                    dai_Controls = new DaiControls();
                return dai_Controls;
            }
            set
            {
                dai_Controls = value;
            }
        }

    }
}
