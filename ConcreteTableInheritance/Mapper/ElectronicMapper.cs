using ConcreteTableInheritance.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ConcreteTableInheritance.Mapper
{
    public class ElectronicMapper:AbstractMapper
    {
        // Yapıcı fonksiyon
        public ElectronicMapper(Gateway gateway)
            : base(gateway)
        {

        }

        // Kayıt bulma
        public Electronic Find(int Id)
        {
            return (Electronic)AbstractFind(Id);
        }
        public override string TableName
        {
            get { return "Electronic"; }
        }

        protected override DomainObject CreateDomainObject()
        {
            return new Electronic();
        }

        // Entity yükleme
        protected override void Load(DomainObject obj, DataRow row)
        {
            // Base mapper çağır veriyi yükle
            base.Load(obj, row);
            // Movies entity özelliklerini yükleme
            Electronic electronic = (Electronic)obj;
        } 
    }
}