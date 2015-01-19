using BLL;
using Gateway.BankServiceReferance;
using Gateway.CreditNoteServiceReferance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gateway
{
    public class GatewayCustomer
    {
        public Customer GetCustomerByTcNo(long tcNo)
        {
            Customer c = new Customer();
            c.TCNo = tcNo;


            BankServiceClient bankService = new BankServiceClient();
            List<Gateway.BankServiceReferance.WorkingBank> workingBanks=bankService.GetWorkingBankByTcNo(tcNo).ToList();
            List<Bank> banks = new List<Bank>();
            banks = workingBanks.Select(i => new Bank() {
                BankID=i.BankId,
                BankaAdi=i.BankName
            }).ToList();
            c.WorkingBanks = banks;

            CreditNoteServiceClient creditNoteService = new CreditNoteServiceClient();
            c.CreditNote=creditNoteService.GetCreditNote(tcNo);

            CustomerModel cm = new CustomerModel();
            c.CustomerName= cm.GetCustomerNameByTcNo(tcNo);

            return c;
        }
    }
}
