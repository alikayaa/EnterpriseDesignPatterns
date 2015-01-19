using ConcreteTableInheritance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcreteTableInheritance.Mapper
{
    public class CategoryMapper : Mapper
    {
        // Entity Getirecek Mapper Sınıflar
        private MoviesMapper m_Movies;
        private ElectronicMapper m_Electronic;
        private ComputerMapper m_Computer;
        private PhoneMapper m_Phone;

        // Category Altındaki tüm entity'lerin Mapper'ları oluşturulur.
        public CategoryMapper(Gateway gateway)
            : base(gateway)
        {
            // Film Mapper
            m_Movies = new MoviesMapper(gateway);
            // Elektronik Mapper
            m_Electronic = new ElectronicMapper(gateway);
            // Bilgisayar Mapper
            m_Computer = new ComputerMapper(gateway);
            // Telefon Mapper
            m_Phone = new PhoneMapper(gateway);
        }
        public override string TableName
        {
            get { return "Kategori"; }
        }

        public Category Find(int Id)
        {
            Category result = null;
            result = m_Movies.Find(Id);
            // Movies içinde bulunduysa dön, yoksa aramaya devam et.
            if (result != null) return result;
            result = m_Electronic.Find(Id);
            // Electronic içinde bulunduysa dön, yoksa aramaya devam et.
            if (result != null) return result;
            result = m_Computer.Find(Id);
            // Computer içinde bulunduysa dön, yoksa aramaya devam et.
            if (result != null) return result;
            // En son phone içerisinde ara.
            result = m_Phone.Find(Id);
            return result;
        }


        protected override DomainObject CreateDomainObject()
        {
            throw new NotImplementedException();
        }
    }
}