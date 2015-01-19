using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Transactions;

namespace GrainedLock
{
    class DBIslem
    {

        public void OgrenciIslem()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Monitor.Enter(this);
                    CoarseGrainedLockEntities db = new CoarseGrainedLockEntities();
                    List<Ogrenci> ogrenciler = db.Ogrenci.ToList();

                    foreach (var ogrenci in ogrenciler)
                    {
                        ogrenci.OgrenciAdi = "Hasan3";
                        List<Ders> aldigiDersler = ogrenci.Ders.ToList();

                        foreach (var aldigiDers in aldigiDersler)
                        {
                            aldigiDers.DersAdi = aldigiDers.DersAdi + " Değişen ders adi";
                        }
                    }
                    db.SaveChanges();
                    
                    ts.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Bir hata oluştu");
                }
                finally
                {
                    Monitor.Exit(this);
                }
            }
        }
    }
}
