using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel
{
    public class PersonCalculater:ICalculate
    {
        public int Calculate(int sallery)
        {
            return sallery + ((sallery * 7) / 100);
        }
    }
}