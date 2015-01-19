using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayerSupertype.Data
{
    public class LayerSupertype
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
