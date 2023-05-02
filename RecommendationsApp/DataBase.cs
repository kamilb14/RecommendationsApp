using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RecommendationsApp
{
    public class DataBase
    {
        SqlConnection connection = new SqlConnection(@"Data Source = recommapp.mssql.somee.com;" + "Initial Catalog = recommapp;" + "User id =AkhKamil_SQLLogin_1;" + "Password = bnyxhv5sxr;");
        public void openConnetion()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

        }
        public void closeConnetion()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }

        }
        public SqlConnection getConnection()
        {
            return connection;
        }
    }
}



