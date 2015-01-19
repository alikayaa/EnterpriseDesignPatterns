using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel
{
    public class DirectorCalculater:ICalculate
    {
        public int Calculate(int sallery)
        {
            return sallery + ((sallery * 15 ) / 100);
        }
    }
}