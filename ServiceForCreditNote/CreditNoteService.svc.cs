using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceForCreditNote
{
    public class CreditNoteService : ICreditNoteService
    {
        public int GetCreditNote(long tcNo)
        {
            //buradan sanki gelen tc kimlik no ya göre kredi notu hesaplattıryor muşuz gibi düşünün.
            return (int)(tcNo / 100000000);
        }
    }
}
