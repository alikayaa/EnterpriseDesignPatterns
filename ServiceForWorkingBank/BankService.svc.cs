using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceForWorkingBank
{
    public class BankService : IBankService
    {

        public List<WorkingBank> GetWorkingBankByTcNo(long tcNo)
        {
            List<WorkingBank> banks = new List<WorkingBank>();
            WorkingBank wb1 = new WorkingBank();
            wb1.BankId = 1;
            wb1.BankName = "Bank 1";

            WorkingBank wb2 = new WorkingBank();
            wb2.BankId = 2;
            wb2.BankName = "Bank 2";

            WorkingBank wb3 = new WorkingBank();
            wb3.BankId = 3;
            wb3.BankName = "Bank 3";

            banks.Add(wb1);
            banks.Add(wb2);
            banks.Add(wb3);

            return banks;

        }
    }
}
