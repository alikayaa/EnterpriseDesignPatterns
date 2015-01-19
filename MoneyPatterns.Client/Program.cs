using MoneyPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyPatterns.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //1000 euro oluşturulur
            Money euroMoney = new Money(MoneyType.Euro, 1000);
            //600 dollar oluşturulu
            Money dollarMoney = new Money(MoneyType.Dollar, 600);

            //1000 euroya 600 doları ekleyelim.
            euroMoney.AddMoney(dollarMoney);

            //eouro muzu gbp ye convert edelim.
            Money gbpMoney=euroMoney.ConvertToMoney(MoneyType.GBP, 2);

            //gbp değerimizi yüzdelerimizi vererek 3 e bölelim
            List<Money> gbpMoneyList=gbpMoney.DivideMoney(3, 30, 40, 30);

            //dolarımız birinci gbp değerinden büyük mü kontrolünü yapalım.
            dollarMoney.isGreaterThan(gbpMoneyList[0]);
        }
    }
}
