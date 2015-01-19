using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowDataGateway
{
    public class CustomerFinder
    {
        //kendisine parametre olarak verilen Customer nesnesini kullanarak 
        //select metodları hazırlar.
        private CustomerGateway customer=null;
        public CustomerFinder(CustomerGateway customer)
        {
            this.customer = customer;
        }

        public List<CustomerGateway> GetCustomerByFirstName()
        {
            
            List<CustomerGateway> results = null;
            using (SqlConnection conn = new SqlConnection(customer.GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = customer.selectByNameStatement;
                sqlCmd.Parameters.Add(new SqlParameter("FirstName", customer.FirstName));
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                    results = new List<CustomerGateway>();
                while (reader.Read())
                {
                    CustomerGateway cust = new CustomerGateway(Convert.ToInt32(reader.GetDecimal(0)),
                    reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4));
                    results.Add(cust);
                }
            }
            return results;
        }
        public List<CustomerGateway> GetCustomerByLastName()
        {
            List<CustomerGateway> results = null;
            using (SqlConnection conn = new SqlConnection(customer.GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = customer.selectByLastNameStatement;
                sqlCmd.Parameters.Add(new SqlParameter("LastName", customer.LastName));
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                    results = new List<CustomerGateway>();
                while (reader.Read())
                {
                    CustomerGateway cust = new CustomerGateway(reader.GetInt32(0),
                    reader.GetString(1), reader.GetString(2),
                    reader.GetDateTime(3), reader.GetString(4));
                    results.Add(cust);
                }
            }
            return results;
        }
        public CustomerGateway GetCustomerbyId()
        {
            CustomerGateway cust = null;
            using (SqlConnection conn = new SqlConnection(customer.GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = customer.selectByIdStatement;
                sqlCmd.Parameters.Add(new SqlParameter("Id", customer.Id));
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    cust = new CustomerGateway();
                    cust.Id = reader.GetInt32(0);
                    cust.FirstName = reader.GetString(1);
                    cust.LastName = reader.GetString(2);
                    cust.DateOfBorn = reader.GetDateTime(3);
                    cust.Country = reader.GetString(4);
                }
            }
            return cust;
        }
        public List<CustomerGateway> GetCustomers()
        {
            List<CustomerGateway> results = null;
            using (SqlConnection conn = new SqlConnection(customer.GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = customer.selectAllStatement;
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                    results = new List<CustomerGateway>();
                while (reader.Read())
                {
                    CustomerGateway cust = new CustomerGateway(reader.GetInt32(0),
                    reader.GetString(1), reader.GetString(2),
                    reader.GetDateTime(3), reader.GetString(4));
                    results.Add(cust);
                }
            }
            return results;
        }

    }
}
