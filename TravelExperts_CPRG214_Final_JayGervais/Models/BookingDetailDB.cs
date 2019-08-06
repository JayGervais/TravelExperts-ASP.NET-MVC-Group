using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TravelExperts_CPRG214_Final_JayGervais.Models
{
    public class BookingDetailDB
    {

        public static List<BookingDetail> getPurchasedDetails(int custID)
        {
            List<BookingDetail> purchasedDetails = new List<BookingDetail>();
            BookingDetail bDetails;

            string getPurchasedDetailsQuery =
                "SELECT bd.BookingId, bd.Description, bd.Destination, bd.BasePrice, bd.AgencyCommission " +
                "FROM Customers AS cs " +
                "INNER JOIN Bookings AS bk " +
                "ON cs.CustomerId = bk.CustomerId " +
                "INNER JOIN BookingDetails AS bd " +
                "ON bk.BookingId = bd.BookingId " +
                "WHERE cs.CustomerId = @CustomerId " +
                "ORDER BY bd.BookingId";

            using (SqlConnection con = TravelExpertsConn.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(getPurchasedDetailsQuery, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", custID);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        bDetails = new BookingDetail();
                        bDetails.BookingId = (int)reader["BookingId"];
                        bDetails.Description = reader["Description"].ToString();
                        bDetails.Destination = reader["Destination"].ToString();
                        bDetails.BasePrice = (decimal)reader["BasePrice"];
                        bDetails.AgencyCommission = (decimal)reader["AgencyCommission"];
                        purchasedDetails.Add(bDetails);
                    }
                    con.Close();
                }
            }
            return purchasedDetails;
        }        
    }
}