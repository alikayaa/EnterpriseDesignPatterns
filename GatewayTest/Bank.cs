using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gateway
{
    public class Bank
    {
        public int BankID { get; set; }
        public string BankaAdi { get; set; }

        public override string ToString()
        {
            return string.Format("BankId={0} ---- BankName={1}",BankID.ToString(),BankaAdi);
        }
    }
}
