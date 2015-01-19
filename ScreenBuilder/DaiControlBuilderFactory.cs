using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenEntity;

namespace ScreenBuilder
{
    public class DaiControlBuilderFactory
    {
        //gelen kontrolün tipine göre ilgili builder nesnesini döneriz.
        internal static DaiControlBuilderBase GetBuilder(DaiControlBase control)
        {
            if (control is DaiTextBox)
                return new DaiTextBoxBuilder();
            throw new Exception("not found");
            //DaiTextBoxBuilder sinifi olmasi lazim class ismi sonuna Builder eklenerek Reflection ile create edilmeli
            //bu sayede if else bloklarından kurtuluruz.
        }
    }
}
