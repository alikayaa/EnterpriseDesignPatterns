using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    //bizim sistemde kullacağımız customer entity' sinin
    //veri tabanıyla hiç bir ilişkisi yok.
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBorn { get; set; }
        public string Country { get; set; }


        #region Yapıcılar

        public Customer()
        {
        }

        public Customer(string firstName, string lastName, DateTime dateOfBorn, string country)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBorn = dateOfBorn;
            this.Country = country;
        }
        public Customer(int id, string firstName, string lastName, DateTime dateOfBorn, string country)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBorn = dateOfBorn;
            this.Country = country;
        }
        #endregion

    }
}
