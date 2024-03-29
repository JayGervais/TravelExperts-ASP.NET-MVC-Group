﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
/// <summary>
/// Customer DB Class by Jay Gervais
/// </summary>
namespace TravelExperts_CPRG214_Final_JayGervais.Models
{
    // customer class written by Jay Gervais
    public class CustomerDB
    {
        // create new customer account
        public static void CreateAccount(Customer cust)
        {
            string addCustomerQuery = @"INSERT INTO Customers " +
                                       "(CustID, CustFirstName, CustLastName, CustAddress, CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, CustBusPhone, CustEmail, CustPass) " +
                                       "VALUES (@CustID, @CustFirstName, @CustLastName, @CustAddress, @CustCity, @CustProv, @CustPostal, @CustCountry, @CustHomePhone, @CustBusPhone, @CustEmail, @CustPass)";

            using (SqlConnection con = TravelExpertsConn.GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(addCustomerQuery, con))
                {
                    // hash password
                    string password = Convert.ToString(cust.CustPass);
                    var hash = PassHash.SecurePasswordHasher.Hash(password);

                    sqlCommand.Parameters.AddWithValue("@CustID", cust.CustID);
                    sqlCommand.Parameters.AddWithValue("@CustFirstName", cust.CustFirstName);
                    sqlCommand.Parameters.AddWithValue("@CustLastName", cust.CustLastName);
                    sqlCommand.Parameters.AddWithValue("@CustAddress", cust.CustAddress);
                    sqlCommand.Parameters.AddWithValue("@CustCity", cust.CustCity);
                    sqlCommand.Parameters.AddWithValue("@CustProv", cust.CustProv);
                    sqlCommand.Parameters.AddWithValue("@CustPostal", cust.CustPostal);
                    sqlCommand.Parameters.AddWithValue("@CustCountry", cust.CustCountry);
                    sqlCommand.Parameters.AddWithValue("@CustHomePhone", cust.CustHomePhone);

                    if (cust.CustBusPhone == null)
                    {
                        sqlCommand.Parameters.AddWithValue("@CustBusPhone", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@CustBusPhone", cust.CustBusPhone);
                    }

                    if (cust.CustEmail == null)
                    {
                        sqlCommand.Parameters.AddWithValue("@CustEmail", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@CustEmail", cust.CustEmail);
                    }

                    sqlCommand.Parameters.AddWithValue("@CustPass", hash);

                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        // customer login
        public static int CustomerLogin(CustomerLogin login)
        {
            int custId = -1;
            string addCustomerQuery = @"SELECT CustomerId, CustPass " +
                                       "FROM Customers WHERE CustID = @CustID";

            using (SqlConnection con = TravelExpertsConn.GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(addCustomerQuery, con))
                {
                    sqlCommand.Parameters.AddWithValue("@CustID", login.CustID);
                    con.Open();
                    SqlDataReader dr = sqlCommand.ExecuteReader();

                    if (dr.Read())
                    {
                        // retrieve and verify password against hash
                        string hashpass = Convert.ToString(dr["CustPass"]);
                        var result = PassHash.SecurePasswordHasher.Verify(login.CustPass, hashpass);
                        if (result)
                        {
                            custId = Convert.ToInt32(dr["CustomerId"]);
                        }
                    }
                    dr.Close();
                }
            }
            return custId;
        }

        // return customer details
        public static Customer CustomerDetails(int custID)
        {
            Customer details = null;
            string noteDetailsQuery = @"SELECT CustID, CustFirstName, CustLastName, CustAddress, CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, CustBusPhone, CustEmail " +
                                       "FROM Customers WHERE CustomerId = @CustomerId";

            using (SqlConnection con = TravelExpertsConn.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(noteDetailsQuery, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", custID);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        details = new Customer();
                        details.CustID = reader["CustID"].ToString();
                        details.CustFirstName = reader["CustFirstName"].ToString();
                        details.CustLastName = reader["CustLastName"].ToString();
                        details.CustAddress = reader["CustAddress"].ToString();
                        details.CustCity = reader["CustCity"].ToString();
                        details.CustProv = reader["CustProv"].ToString();
                        details.CustPostal = reader["CustPostal"].ToString();
                        details.CustCountry = reader["CustCountry"].ToString();
                        details.CustHomePhone = reader["CustHomePhone"].ToString();
                        details.CustBusPhone = reader["CustBusPhone"].ToString();
                        details.CustEmail = reader["CustEmail"].ToString();

                        //if (reader["AgentId"] != DBNull.Value)
                        //{
                        //    details.AgentId = Convert.ToInt32(reader["AgentId"]);
                        //}
                        //else
                        //{
                        //    details.AgentId = null;
                        //}
                    }
                    con.Close();
                }
            }
            return details;
        }

        // edit customer
        public static int EditCustomer(int id, Customer newCust)
        {
            int updateCount = 0;
            string updateQuery = @"UPDATE Customers " +
                                  "SET CustID = @CustID, " +
                                  "CustFirstName = @CustFirstName, " +
                                  "CustLastName = @CustLastName, " +
                                  "CustAddress = @CustAddress, " +
                                  "CustCity = @CustCity, " +
                                  "CustProv = @CustProv, " +
                                  "CustPostal = @CustPostal, " +
                                  "CustCountry = @CustCountry, " +
                                  "CustHomePhone = @CustHomePhone, " +
                                  "CustBusPhone = @CustBusPhone, " +
                                  "CustEmail = @CustEmail, " +
                                  "CustPass = @CustPass " +
                                  "WHERE CustomerId = @CurrentCustId";

            using (SqlConnection con = TravelExpertsConn.GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand(updateQuery, con))
                {

                    string password = Convert.ToString(newCust.CustPass);
                    var hash = PassHash.SecurePasswordHasher.Hash(password);

                    sqlCommand.Parameters.AddWithValue("@CurrentCustId", id);
                    sqlCommand.Parameters.AddWithValue("@CustID", newCust.CustID);
                    sqlCommand.Parameters.AddWithValue("@CustFirstName", newCust.CustFirstName);
                    sqlCommand.Parameters.AddWithValue("@CustLastName", newCust.CustLastName);
                    sqlCommand.Parameters.AddWithValue("@CustAddress", newCust.CustAddress);
                    sqlCommand.Parameters.AddWithValue("@CustCity", newCust.CustCity);
                    sqlCommand.Parameters.AddWithValue("@CustProv", newCust.CustProv);
                    sqlCommand.Parameters.AddWithValue("@CustPostal", newCust.CustPostal);
                    sqlCommand.Parameters.AddWithValue("@CustCountry", newCust.CustCountry);
                    sqlCommand.Parameters.AddWithValue("@CustHomePhone", newCust.CustHomePhone);
                    sqlCommand.Parameters.AddWithValue("@CustBusPhone", newCust.CustBusPhone);
                    sqlCommand.Parameters.AddWithValue("@CustEmail", newCust.CustEmail);

                    //if (newCust.AgentId == null)
                    //{
                    //    sqlCommand.Parameters.AddWithValue("@AgentId", DBNull.Value);
                    //}
                    //else
                    //{
                    //    sqlCommand.Parameters.AddWithValue("@AgentId", Convert.ToInt32(newCust.AgentId));
                    //}

                    sqlCommand.Parameters.AddWithValue("@CustPass", hash);
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            return updateCount;
        }

        // list function for retrieving AgentIds - created for later enabling
        public static List<int?> GetAgentIdDropdown()
        {
            List<int?> agentIdList = new List<int?>();
            string getAgentIdQuery = @"SELECT AgentId FROM Agents";

            using (SqlConnection con = TravelExpertsConn.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(getAgentIdQuery, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Customer Agents = new Customer();
                    while (reader.Read())
                    {
                        Agents.AgentId = Convert.ToInt32(reader["AgentId"]);
                        agentIdList.Add(Agents.AgentId);
                    }
                    con.Close();
                }
            }
            return agentIdList;
        }
    }
}