using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TravelExperts_CPRG214_Final_JayGervais.Models
{
    public class TravelExpertsConn
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"data source=localhost\SAITSQLEXPRESS;initial catalog=TravelExperts;integrated security=True";
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
    }
}