using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace MidTerm_Demo
{
    class Modify
    {
        public Modify()
        {

        }
        SqlCommand sqlCommand; // Truy van cac cau lenh insert, delete,..
        SqlDataReader dataReader; // doc du lieu trong table
        public List<Account> accounts (string query) // check tai khoan
        {
            List<Account> accounts = new List<Account>();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())   
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    accounts.Add(new Account(dataReader.GetString(0), dataReader.GetString(1)));
                }
                sqlConnection.Close();
            }
            return accounts;
        }
        public void Command (string query) // Dung de dang ky tai khhoan
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();//thuc thi cau truy van
                 

                sqlConnection.Close();
            }
        }

        

        public void Command1(string query1) // Dung de doi mat khau
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query1, sqlConnection);
                sqlCommand.ExecuteNonQuery();//thuc thi cau truy van


                sqlConnection.Close();
            }
        }

    }
}
