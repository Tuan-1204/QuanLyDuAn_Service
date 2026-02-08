using System;
using System.Configuration;
using System.Data.SqlClient;

namespace MyApp.DAL
{
    public class Db
    {
        public static SqlConnection CreateConn()
        {
           
            string s = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            return new SqlConnection(s);
        }
    }
}