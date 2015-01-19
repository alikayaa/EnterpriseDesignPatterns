using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AssociationTableMapping
{
    public class MusteriMapper : AbstractMapper
    {
        // Müşteri Bul
        public Musteri Find(int Id)
        {
            return (Musteri)AbstractFind(Id);
        }

        // Müşterinin Aldığı Ürünleri Yükle.
        public IList LoadProduct(Musteri musteri)
        {
            // Ürün Haritalama nesnesi.
            UrunMapper urunMapper = new UrunMapper();
            urunMapper.dsh.Data = this.dsh.Data;
            // Müşterinin Aldığı ürünleri veri tabanından getir.
            DataRow[] rows = this.musterininAldigiUrunler(musteri);
            // Bir liste oluştur. Listenin içerisine ürünleri ekle.
            IList result = new ArrayList();
            foreach (DataRow row in rows)
            {
                int urunId = (int)row["UrunID"];
                // Ürün Mapper ile yeni ürün oluştur, müşteri ürünlerine ekle.
                musteri.UrunEkle(urunMapper.Find(urunId));
            }
            // Müşterinin aldığı tüm ürünler listeye eklenir, ve geri döndürülür.
            return result;
        }

        // Müşteri Entity'sini Yükle
        protected override void LoadEntity(DomainObject domainObject, DataRow row)
        {
            Musteri musteri = (Musteri)domainObject;
            musteri.Adi = row["Adi"].ToString();
            this.LoadProduct(musteri);
        }


        protected override String TableName
        {
            get { return "Musteri"; }
        }

        protected override DomainObject CreateDomainObject()
        {
            return new Musteri();
        }

        private DataRow[] musterininAldigiUrunler(Musteri musteri)
        {
            String filter = String.Format("MusteriID = {0}", musteri.ID);
            return musteriUrunleri.Select(filter);
        }
        private DataTable musteriUrunleri
        {
            get { return dsh.Data.Tables["MusteriUrun"]; }
        }
    }
}