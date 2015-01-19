using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableDataGateway
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

        public string GetConnectionString()
        {
            string sConnectionString = string.Empty;
            return sConnectionString;
        }

        #region Methods
        //ekleme işlemini yaparken kendi içindeki property'leri
        //kullanarak işlem yapar.
        public int AddCustomer(string firstName, string lastName, DateTime dateOfBorn, string country)
        {
            int nResult = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = insertStatement;
                sqlCmd.Parameters.Add(new SqlParameter("FirstName", firstName));
                sqlCmd.Parameters.Add(new SqlParameter("LastName", lastName));
                sqlCmd.Parameters.Add(new SqlParameter("DateOfBorn", dateOfBorn));
                sqlCmd.Parameters.Add(new SqlParameter("Country", country));
                conn.Open();
                nResult = sqlCmd.ExecuteNonQuery();
            }
            return nResult;
        }
        //silme işlemini yaparken kendi içindeki Id property' sini
        //kullanarak işlem yapar.
        public int RemoveCustomer(int id)
        {
            int nResult = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = deleteStatement;
                sqlCmd.Parameters.Add(new SqlParameter("Id", id));
                conn.Open();
                nResult = sqlCmd.ExecuteNonQuery();
                conn.Close();
            }
            return 0;
        }
        //güncelleme işlemini yaparken kendi içindeki property'leri
        //kullanarak işlem yapar.
        public int UpdateCustomer(int id, string firstName, string lastName, DateTime dateOfBorn, string country)
        {
            int nResult = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = updateStatement;
                sqlCmd.Parameters.Add(new SqlParameter("Id", id));
                sqlCmd.Parameters.Add(new SqlParameter("FirstName", firstName));
                sqlCmd.Parameters.Add(new SqlParameter("LastName", lastName));
                sqlCmd.Parameters.Add(new SqlParameter("DateOfBorn", dateOfBorn));
                sqlCmd.Parameters.Add(new SqlParameter("Country", country));
                conn.Open();
                nResult = sqlCmd.ExecuteNonQuery();
            }
            return nResult;
        }

        //verinin get edildiği metodlarda geriye map edilmiş DTO nesnesi de
        //dönülebilir.
        public SqlDataReader GetCustomerByFirstName(string firstName)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = selectByNameStatement;
                sqlCmd.Parameters.Add(new SqlParameter("FirstName", firstName));
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
        }
        public SqlDataReader GetCustomerByLastName(string lastName)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = selectByLastNameStatement;
                sqlCmd.Parameters.Add(new SqlParameter("LastName", lastName));
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
        }
        public SqlDataReader GetCustomerbyId(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = selectByIdStatement;
                sqlCmd.Parameters.Add(new SqlParameter("Id", id));
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
        }
        public SqlDataReader GetCustomers()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = selectAllStatement;
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
        }


        #endregion

    }
}
