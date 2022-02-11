using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MidTerm_Demo
{
    class Connection
    {
        private static string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hnamu\OneDrive\Desktop\Thư mục mới\GKi\MidTerm_Demo\Database1.mdf;Integrated Security=True";
        
        public static SqlConnection GetSqlConnection ()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
