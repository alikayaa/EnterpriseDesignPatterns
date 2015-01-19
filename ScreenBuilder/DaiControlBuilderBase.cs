using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using ScreenEntity;

namespace ScreenBuilder
{
    //Bütün kontrollerimiz için builder nesneleri gerekmektedir.
    //bizim kontrollerimizi işleyecek ve Control sınıfı tipinde 
    //bir sınıf dönecek olması gerekiyor.
    public abstract class DaiControlBuilderBase
    {
        internal abstract Control Build(DaiControlBase control);
    }
}
