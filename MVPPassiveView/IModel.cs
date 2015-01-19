using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVPPassiveView
{
    public interface IModel
    {
        void sayiyiArttir();
        void sayiyiAzalt();
        void setvalue(int v);
        int getValue();
    }
}
