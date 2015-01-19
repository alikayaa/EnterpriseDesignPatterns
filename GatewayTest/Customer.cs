using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gateway
{
    public class Customer
    {
        public long TCNo { get; set; }
        public string CustomerName { get; set; }
        public List<Bank> WorkingBanks { get; set; }
        public int CreditNote { get; set; }

        public override string ToString()
        {
            string workingbank="";
            WorkingBanks.ForEach(i => workingbank += i.ToString());

            string result = string.Format("TcNo: {0} \nCustomerName: {1} \nWorkingBank= {2} \n CreditNote: {3}"
                , TCNo.ToString(), CustomerName, workingbank,CreditNote.ToString());
            return result;
        }


    }
}
