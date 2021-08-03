using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnLac.Models
{
    public class DatabaseService
    {
        string strConnection;
        public DatabaseService()
        {
            strConnection = ConfigurationManager.ConnectionStrings["DoAnConnectionString"].ConnectionString;
        }

        public SqlConnection getConnection()
        {
            return new SqlConnection(strConnection);
        }
    }
}