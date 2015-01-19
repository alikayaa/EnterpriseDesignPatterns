using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveRecord
{
    public class Customer
    {
        #region Statements

        public string insertStatement = "insert into Customer(FirstName, LastName, DateOfBorn, Country) values(@FirstName, @LastName, @DateOfBorn, @Country)";
        public string deleteStatement = "delete Customer where Id=@Id";
        public string updateStatement = "update Customer set FirstName=@FirstName, LastName=@LastName, DateOfBorn=@DateOfBorn, Country=@Country where Id=@Id";
        public string selectAllStatement = "select * from Customer";
        public string selectByIdStatement = "select * from Customer where Id=@Id";

        #region Business Select Statements

        public string selectAfterDate = "select * from Customer where DateOfBorn > @DateOfBorn";
        public string selectCount = "select Count(*) from Customer";

        #endregion

        #endregion

        #region Properties

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBorn { get; set; }
        public string Country { get; set; }

        #endregion

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
            return 0;
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

        #region Find Metods

        public Customer GetCustomerbyId()
        {
            Customer cust = null;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = selectByIdStatement;
                sqlCmd.Parameters.Add(new SqlParameter("Id", Id));
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    cust = new Customer();
                    cust.Id = reader.GetInt32(0);
                    cust.FirstName = reader.GetString(1);
                    cust.LastName = reader.GetString(2);
                    cust.DateOfBorn = reader.GetDateTime(3);
                    cust.Country = reader.GetString(4);
                }
            }
            return cust;
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> results = null;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = selectAllStatement;
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                    results = new List<Customer>();
                while (reader.Read())
                {
                    Customer cust = new Customer(reader.GetInt32(0),
                    reader.GetString(1), reader.GetString(2),
                    reader.GetDateTime(3), reader.GetString(4));
                    results.Add(cust);
                }
            }
            return results;
        }

        #endregion

        #region Business Methods

        public List<Customer> GetCustomerBornAfterDate(DateTime datetime)
        {
            List<Customer> results = null;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = selectAfterDate;
                sqlCmd.Parameters.Add(new SqlParameter("DateOfBorn", datetime));
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                    results = new List<Customer>();
                while (reader.Read())
                {
                    Customer cust = new Customer(reader.GetInt32(0),
                    reader.GetString(1), reader.GetString(2),
                    reader.GetDateTime(3), reader.GetString(4));
                    results.Add(cust);
                }
            }
            return results;
        
        }

        public int GetCustomerCount()
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = selectCount;
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    count=reader.GetInt32(0);
                }
            }
            return count;
        }

        #endregion


    }
}
