using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    //customer entity' si ile alakalı mapper işlemlerini bu sınıfımızda
    //gerçekliyoruz. veri tabanıyla bağlantılı olan nesnemiz bu sınıfımızdır.
    //işte bu sayede domain katmanı veri tabanındaki şemanın değişmesinden etkilenmez
    //çünkü o yapacağı işlemlerde Customer entity' sini kullanır.
    public class CustomerDataMapper:IDataMapper<Customer>
    {
        string ConnectionString { get; set; }

        public int Delete(Customer entity)
        {
            int nResult = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = "delete Customer where Id=@Id";
                sqlCmd.Parameters.Add(new SqlParameter("Id", entity.Id));
                conn.Open();
                nResult = sqlCmd.ExecuteNonQuery();
                conn.Close();
            }
            return nResult;
        }

        public void Insert(Customer entity)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = "insert into Customer(FirstName, LastName, DateOfBorn, Country) values(@FirstName, @LastName, @DateOfBorn, @Country); @@Identity";
                sqlCmd.Parameters.Add(new SqlParameter("FirstName", entity.FirstName));
                sqlCmd.Parameters.Add(new SqlParameter("LastName", entity.LastName));
                sqlCmd.Parameters.Add(new SqlParameter("DateOfBorn", entity.DateOfBorn));
                sqlCmd.Parameters.Add(new SqlParameter("Country", entity.Country));
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                    entity.Id = reader.GetInt32(0);
                else
                    throw new Exception("Ekleme işlemi başarısız.");
            }
        }

        public void Update(Customer entity)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = "update Customer set FirstName=@FirstName, LastName=@LastName, DateOfBorn=@DateOfBorn, Country=@Country where Id=@Id";
                sqlCmd.Parameters.Add(new SqlParameter("Id", entity.Id));
                sqlCmd.Parameters.Add(new SqlParameter("FirstName", entity.FirstName));
                sqlCmd.Parameters.Add(new SqlParameter("LastName", entity.LastName));
                sqlCmd.Parameters.Add(new SqlParameter("DateOfBorn", entity.DateOfBorn));
                sqlCmd.Parameters.Add(new SqlParameter("Country", entity.Country));
                conn.Open();
                sqlCmd.ExecuteNonQuery();
            }
        }

        public List<Customer> GetAll()
        {
            List<Customer> results = null;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = "select * from Customer";
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

        public Customer GetById(int id)
        {
            Customer cust = null;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = "select * from Customer where Id=@Id";
                sqlCmd.Parameters.Add(new SqlParameter("Id", id));
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

        
    }
}
