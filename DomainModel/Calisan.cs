using DAI.Orm;
using DAI.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel
{
    public class Calisan:IModel
    {
        [AutoInc(1,1)]
        public int Id { get; set; }
        [INT]
        [NOTNULL]
        public int Sallery { get; set; }
        [NVARCHAR(255)]
        [NOTNULL]
        public string Name { get; set; }
        [BOOLEAN]
        public bool isDirector { get; set; }
    }
}