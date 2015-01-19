using ConcreteTableInheritance.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ConcreteTableInheritance.Mapper
{
    public class PhoneMapper : AbstractMapper
    {

        // Yapıcı fonksiyon
        public PhoneMapper(Gateway gateway)
            : base(gateway)
        {

        }

        public override string TableName
        {
            get { return "Phone"; }
        }

        protected override DomainObject CreateDomainObject()
        {
            return new Phone();
        }

        // Kayıt bulma
        public Phone Find(int Id)
        {
            return (Phone)AbstractFind(Id);
        }

        // Entity yükleme
        protected override void Load(DomainObject obj, DataRow row)
        {
            // Base mapper çağır veriyi yükle
            base.Load(obj, row);
            Phone phone = (Phone)obj;
            phone.FourG = row["4GDestegi"].ToString();
            phone.Aciklama = row["Aciklama"].ToString();
            phone.EkranGenisligi = row["EkranGenisligi"].ToString();
           
        }
    }
}