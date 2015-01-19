using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class ValidationManager
    {
        public bool IsValid<T>(T Entity)
        {
            bool result = false;

            Type type = Entity.GetType();

            foreach (var item in type.GetProperties())
            {
                if (item.Name == "Id" && Convert.ToInt32(item.GetValue(Entity)) != 0)
                    result = true;
            }
            return result;
        }
    }
}
