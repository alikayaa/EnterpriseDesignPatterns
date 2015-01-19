using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyPattern
{
    public class Money
    {
        #region Private Fields
        //Para tipini enum bir tipte tutuyoruz.
        private MoneyType moneyType;
        //para miktarını da decimal bir tipte tutuyoruz
        private decimal amount;

        #endregion

        #region Properties
        //para tipinin dışarıdan değiştirilememesi için kapsüllüyoruz.
        public MoneyType MoneyType
        {
            get { return moneyType; }
        }
        //amountunda dışarıdan erişilememesi için kapsüllüyoruz.
        public decimal Amount
        {
            get { return amount; }
        }
        //kur bilgisinin para birimine göre alınmasını sağlamak için
        //kapsülleme işlemi yapıyoruz.
        public decimal Rate
        {
            get { return GetMoneyRate(moneyType); }
        }

        #endregion

        #region Constructer
        //yapıcı metodumuzda sadece para birimi ve miktarını alıyoruz.
        public Money(MoneyType type, decimal amount)
        {
            this.amount = amount;
            this.moneyType = type;
        }

        #endregion

        #region Private Methods
        //bu metodun sanki ilgili günün rate bilgilerini
        //döndüğünü düşünüyoruz
        private decimal GetMoneyRate(MoneyType type)
        {
            //burada paranın kur bilgilerinin alındığını düşünüelim.
            decimal rate = 0;
            switch (type)
            {
                case MoneyType.TL:
                    rate = 1M;
                    break;
                case MoneyType.Dollar:
                    rate = 2.35M;
                    break;
                case MoneyType.Euro:
                    rate = 2.95M;
                    break;
                case MoneyType.GBP:
                    rate = 3.35M;
                    break;
                case MoneyType.JPY:
                    rate = 0.55M;
                    break;
                default:
                    rate = 1M;
                    break;
            }
            return rate;
        }

        #endregion

        #region Public Methods
        //para biriminleri arasında convert işlemlerimizi bu metod vasıtasıyla
        //yapacağız. Sadece çevirmek istediğimiz para birimini hassasiyet bilgisini 
        //veriyoruz.
        public Money ConvertToMoney(MoneyType type,int roundSensitive)
        {
            //eğer çevrilmesini istediğimiz tip ile aynı tip ise aynı tipi dönüyoruz.
            if (Enum.Equals(moneyType, type))
                return this;
            else
            {
                //Toplam TL tutar bulundu.
                decimal totalTlValue = this.amount * this.Rate; 
                //istenen tipin rate değeri bulunmadı.
                decimal convertRateValue = GetMoneyRate(type);
                //istenen kur tipinden toplam amount miktarı hesaplandı.
                decimal convertAmount = Math.Round(totalTlValue / convertRateValue, roundSensitive);
                //yeni para birimi ve amounta göre paramız oluştuurlur.
                Money returnMoney = new Money(type,convertAmount);
                return returnMoney;
            }
        }
        //bu metodla paramızı kaça böleceğimizi ve hangi yüzdeyle böleceğimizi veririz.
        public List<Money> DivideMoney(int divideCount, params decimal[] percent)
        {
            //bölünmesini istediğimiz miktar ile parametre ile gelen yüzdeler
            //eşit değilse ve yüzdelerin toplamı yüz etmiyorsa hata fırlat.
            if (divideCount != percent.Count() || percent.Sum(i=>i)!=100)
                throw new Exception("hata");
            List<Money> results = new List<Money>();

            //istenen yüzdeler içerisinde dönülür.
            foreach (var item in percent)
            {
                //her bir yüzde için çarpım değeri hesaplanır.
                decimal temp = item / 100;
                //paranın çarpım değerine göre miktarı hesaplanır.
                decimal newAmount = Math.Round(this.amount * temp, 2);
                //yeni para oluşturulur ve listeye eklenir.
                Money money = new Money(this.moneyType, newAmount);
                results.Add(money);
            }
            //en sonunda para kaybetmememiz için toplam para ile 
            //bölünen paraların tamamı birbirinden çıkarılır.
            decimal restAmount = this.amount - results.Sum(i => i.amount);
            //kalan para birinciye eklenir. Bu kısmı kural değil herhangi 
            //birine eklenebilirdi.
            results[0].amount += restAmount;
            return results;
        }

        public override string ToString()
        {
            //paranın currency bilgisi ile birlikte yazdırılması için
            //ToString metodu override edilir.
            return this.moneyType.ToString() + " " + this.amount.ToString("0.00");
        }

        //equals metodu override edilir ve kur bilgisi ve
        //amount aynı olan nesnelerin birbirine eşit olması 
        //durumuna göre yeniden dizayn edilir.
        public override bool Equals(object obj)
        {
            if (obj is Money)
            {
                Money money = obj as Money;
                return this.moneyType == money.moneyType && this.amount == money.amount;
            }
            else
            {
                return false;
            }
        }
        //iki para birimi arasında büyüklük karşılaştırılması yapılması için
        //kullanılacak olan metodlar
        public bool isGreaterThan(Money money)
        {
            decimal amount = this.ConvertToMoney(MoneyType.TL,2).amount;
            decimal otherAmount = money.ConvertToMoney(MoneyType.TL, 2).amount;
            decimal div=amount-otherAmount;
            div=div>0?div:-1*div;
            return div > 0.01M;
        }

        public bool isLessThan(Money money)
        {
            decimal amount = this.ConvertToMoney(MoneyType.TL, 2).amount;
            decimal otherAmount = money.ConvertToMoney(MoneyType.TL, 2).amount;
            decimal div = otherAmount-amount;
            div = div > 0 ? div : -1 * div;
            return div > 0.01M;
        }

        //mevcut paramıza yeni para eklemeye yarayan metod
        //örneğin Euro olan bir paraya dollar eklenebilir.
        public bool AddMoney(Money money)
        {
            //önce mevcut paranın tl cinsinden tutarı bulunur.
            decimal tlAmount=this.ConvertToMoney(MoneyPattern.MoneyType.TL, 2).amount;
            //daha sonra eklenmek istenen paranın tl cinsinden tutarı bulunur.
            decimal otherTlAmount = money.ConvertToMoney(MoneyPattern.MoneyType.TL, 2).amount;
            //daha sonra bu iki paranın toplamı mevcut sınıfımızın currency değerine çevrilir.
            decimal lastAmount = Math.Round((tlAmount + otherTlAmount) / this.GetMoneyRate(this.moneyType), 2);
            //amoutumuz güncellenir.
            this.amount = lastAmount;
            return true;
        }

        //aynı şekilde para çıkarma veya zaman bilgisi de koyarak sınıfımızı ihtiyaçlarımıza göre
        //zenginleştirebiliriz. Örneğin bir ürünümüz sattığımız zamanki kur bilgileri ile çalışmamız gerekecektir. 
        //ayrıca bir tarih alanı ekleyip getRate metodumuzu buna göre de güncelleyebiliriz.

        #endregion
    }
}
