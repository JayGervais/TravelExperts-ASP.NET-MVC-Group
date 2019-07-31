using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
/// <summary>
/// Package DB Class by Jay Gervais
/// </summary>
namespace TravelExperts_CPRG214_Final_JayGervais.Models
{
    public class PackageDB
    {
        public static List<Package> GetPackages()
        {
            List<Package> packageList = new List<Package>();
            string getPkgQuery = @"SELECT PackageId, PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission, PkgImage " +
                                   "FROM Packages";

            using (SqlConnection con = TravelExpertsConn.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(getPkgQuery, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Package packages;
                    while (reader.Read())
                    {
                        packages = new Package();
                        packages.PackageId = Convert.ToInt32(reader["PackageId"]);
                        packages.PkgName = reader["PkgName"].ToString();
                        packages.PkgStartDate = Convert.ToDateTime(reader["PkgStartDate"]);
                        packages.PkgEndDate = Convert.ToDateTime(reader["PkgEndDate"]);
                        packages.PkgDesc = Convert.ToString(reader["PkgDesc"]);
                        packages.PkgBasePrice = Convert.ToInt32(reader["PkgBasePrice"]);
                        packages.PkgAgencyCommission = Convert.ToInt32(reader["PkgAgencyCommission"]);
                        packages.PkgImage = reader["PkgImage"].ToString();
                        packageList.Add(packages);
                    }
                    con.Close();
                }
            }
            return packageList;
        }


    }
}