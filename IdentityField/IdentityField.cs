using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityField
{
    public class DomainObject
    {
        public const long PLACEHOLDER_ID = -1;
        public long Id = PLACEHOLDER_ID;
        public Boolean isNew() { return Id == PLACEHOLDER_ID; }
    }
}