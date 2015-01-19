using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializedBlob
{
    interface IExpression
    {
        void BuildControl(Context context);
    }
}
