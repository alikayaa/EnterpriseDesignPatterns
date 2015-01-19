using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AssociationTableMapping
{
    public class UrunMapper:AbstractMapper
    {
        public Urun Find(int Id)
        {
            return (Urun)AbstractFind(Id);
        }

        public IList LoadCustomer(Urun urun)
        {
            // Ürün Haritalama nesnesi.
            MusteriMapper musteriMapper = new MusteriMapper();
            // Müşterinin Aldığı ürünleri veri tabanından getir.
            DataRow[] rows = this.urunSatilanMusteriler(urun);
            // Bir liste oluştur. Listenin içerisine ürünleri ekle.
            IList result = new ArrayList();
            foreach (DataRow row in rows)
            {
                int musteriId = (int)row["MusteriID"];
                // Ürün Mapper ile yeni ürün oluştur, müşteri ürünlerine ekle.
                urun.MusteriEkle(musteriMapper.Find(musteriId));
            }
            // Müşterinin aldığı tüm ürünler listeye eklenir, ve geri döndürülür.
            return result;

        }
        protected override void LoadEntity(DomainObject domainObject, System.Data.DataRow row)
        {
            Urun urun = (Urun)domainObject;
            urun.Adi = row["Adi"].ToString();
        }

        protected override string TableName
        {
            get { return "Urun"; }
        }

        protected override DomainObject CreateDomainObject()
        {
            return new Urun();
        }

        private DataRow[] urunSatilanMusteriler(Urun urun)
        {
            String filter = String.Format("UrunID = {0}", urun.ID);
            return musteriler.Select(filter);
        }
        private DataTable musteriler
        {
            get { return dsh.Data.Tables["MusteriUrun"]; }
        }
    }
}