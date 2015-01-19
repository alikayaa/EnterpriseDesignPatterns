using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowDataGateway
{
    public class CustomerGateway
    {
        #region Statements

        public string insertStatement = "insert into Customer(FirstName, LastName, DateOfBorn, Country) values(@FirstName, @LastName, @DateOfBorn, @Country)";
        public string deleteStatement = "delete Customer where Id=@Id";
        public string updateStatement = "update Customer set FirstName=@FirstName, LastName=@LastName, DateOfBorn=@DateOfBorn, Country=@Country where Id=@Id";
        public string selectAllStatement = "select * from Customer";
        public string selectByIdStatement = "select * from Customer where Id=@Id";
        public string selectByNameStatement = "select * from Customer where firstname=@FirstName";
        public string selectByLastNameStatement = "select * from Customer where lastname=@LastName";

        #endregion

        #region Properties

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBorn { get; set; }
        public string Country { get; set; }

        #endregion

        #region Yapıcılar

        public CustomerGateway()
        {
        }

        public CustomerGateway(string firstName, string lastName, DateTime dateOfBorn, string country)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBorn = dateOfBorn;
            this.Country = country;
        }
        public CustomerGateway(int id, string firstName, string lastName, DateTime dateOfBorn, string country)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBorn = dateOfBorn;
            this.Country = country;
        }
        public string GetConnectionString()
        {
            string sConnectionString = string.Empty;
            return sConnectionString;
        }

        #endregion

        #region Methods
        //ekleme işlemini yaparken kendi içindeki property'leri
        //kullanarak işlem yapar.
        public int AddCustomer()
        {
            int nResult = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = insertStatement;
                sqlCmd.Parameters.Add(new SqlParameter("FirstName", FirstName));
                sqlCmd.Parameters.Add(new SqlParameter("LastName", LastName));
                sqlCmd.Parameters.Add(new SqlParameter("DateOfBorn", DateOfBorn));
                sqlCmd.Parameters.Add(new SqlParameter("Country", Country));
                conn.Open();
                nResult = sqlCmd.ExecuteNonQuery();
            }
            return nResult;
        }
        //silme işlemini yaparken kendi içindeki Id property' sini
        //kullanarak işlem yapar.
        public int RemoveCustomer()
        {
            int nResult = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = deleteStatement;
                sqlCmd.Parameters.Add(new SqlParameter("Id", Id));
                conn.Open();
                nResult = sqlCmd.ExecuteNonQuery();
                conn.Close();
            }
            return nResult;
        }
        //güncelleme işlemini yaparken kendi içindeki property'leri
        //kullanarak işlem yapar.
        public int UpdateCustomer()
        {
            int nResult = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = updateStatement;
                sqlCmd.Parameters.Add(new SqlParameter("Id", Id));
                sqlCmd.Parameters.Add(new SqlParameter("FirstName", FirstName));
                sqlCmd.Parameters.Add(new SqlParameter("LastName", LastName));
                sqlCmd.Parameters.Add(new SqlParameter("DateOfBorn", DateOfBorn));
                sqlCmd.Parameters.Add(new SqlParameter("Country", Country));
                conn.Open();
                nResult = sqlCmd.ExecuteNonQuery();
            }
            return nResult;
        }
        
        #endregion
    }
}




