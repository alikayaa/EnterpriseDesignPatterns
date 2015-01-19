using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVPPassiveView
{
    public class SayiIslemModel:IModel
    {
        private int _value;

        public void sayiyiArttir()
        {
            _value++;
        }

        public void sayiyiAzalt()
        {
            _value--;
        }

        public void setvalue(int v)
        {
            _value = v;
        }


        public int getValue()
        {
            return _value;
        }
    }
}
