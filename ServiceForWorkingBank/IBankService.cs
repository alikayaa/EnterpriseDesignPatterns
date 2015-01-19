using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceForWorkingBank
{
    [ServiceContract]
    public interface IBankService
    {
        [OperationContract]
        List<WorkingBank> GetWorkingBankByTcNo(long tcNo);
    }


    [DataContract]
    public class WorkingBank
    {
        int bankId = 0;
        string bankName = "";

        [DataMember]
        public int BankId
        {
            get { return bankId; }
            set { bankId = value; }
        }

        [DataMember]
        public string BankName
        {
            get { return bankName; }
            set { bankName = value; }
        }
    }
}
