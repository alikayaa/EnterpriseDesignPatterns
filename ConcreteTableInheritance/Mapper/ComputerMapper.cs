using ConcreteTableInheritance.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ConcreteTableInheritance.Mapper
{
    public class ComputerMapper:AbstractMapper
    {

        // Yapıcı fonksiyon
        public ComputerMapper(Gateway gateway)
            : base(gateway)
        {

        }

        public override string TableName
        {
            get { return "Computer"; }
        }

        protected override DomainObject CreateDomainObject()
        {
            return new Computer();
        }

        // Kayıt bulma
        public Computer Find(int Id)
        {
            return (Computer)AbstractFind(Id);
        }

        // Entity yükleme
        protected override void Load(DomainObject obj, DataRow row)
        {
            // Base mapper çağır veriyi yükle
            base.Load(obj, row);
            Computer computer = (Computer)obj;
            computer.Depolama = row["Depolama"].ToString();
            computer.EkranTipi = row["EkranTipi"].ToString();

        }
    }
}