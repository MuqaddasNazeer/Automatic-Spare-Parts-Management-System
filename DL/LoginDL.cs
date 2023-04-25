using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject.DL
{
    public class LoginDL
    {
        public static bool Shoplogin(string sc, string username, string password)
        {

            try
            {
                SqlConnection conn = new SqlConnection(sc);
                conn.Open();
                SqlCommand cm = new SqlCommand("select * from Login where Username='" + username + "' AND Password='" + password + "'", conn);
                SqlDataReader dr = cm.ExecuteReader(); //execute query  \\dr isdata  reader//
                if (dr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception exp)
            {
                return false;
            }
        }
    }
}