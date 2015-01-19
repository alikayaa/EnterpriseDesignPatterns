using ConcreteTableInheritance.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ConcreteTableInheritance.Mapper
{
    public class MoviesMapper:AbstractMapper
    {

        // Yapıcı fonksiyon
        public MoviesMapper(Gateway gateway):base(gateway)
        {

        }

        // Kayıt bulma
        public Movies Find(int Id)
        {
            return (Movies)AbstractFind(Id);
        }
       
        // Veri tabanı kaydına uygun domain object oluşturma.
        // Movies kayıtlarını döndüreceği için Movies instance döndürülür.
        protected override DomainObject CreateDomainObject()
        {
            return new Movies();
        }

        // Kayıtların aranacağı tablo adı.
        public override string TableName
        {
            get { return "Movies"; }
        }

        // Entity yükleme
        protected override void Load(DomainObject obj, DataRow row) { 
            // Base mapper çağır veriyi yükle
            base.Load(obj, row);
            // Movies entity özelliklerini yükleme
            Movies movie = (Movies)obj;
            movie.Aciklama = row["Aciklama"].ToString();
            
        } 
    }
}