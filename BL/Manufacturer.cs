using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FinalProject.BL
{
    public class Manufacturer
    {
        private string Address;
        private string BusinessName;
        private string JobTitle;
        private string ContactName;
        private float Rank;

        public Manufacturer(string Address, string BusinessName, string JobTitle, string ContactName,float Rank)
        {
            this.Address = Address;           
            this.BusinessName = BusinessName;
            this.JobTitle = JobTitle;
            this.ContactName = ContactName;
            this.Rank = Rank;
        }
        public static string AddManufacturer(Manufacturer m, string con)
        {
            string ans = "done";
                SqlConnection conn = new SqlConnection(con);
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Manufacturer(Address,BusinessName,JobTitle,ContactName,Rank) values(@Address,@BusinessName,@JobTitle,@ContactName,@Rank)", conn);

                cmd.Parameters.AddWithValue("@BusinessName", m.BusinessName);
                cmd.Parameters.AddWithValue("@Address", m.Address);
                cmd.Parameters.AddWithValue("@JobTitle", m.JobTitle);
                cmd.Parameters.AddWithValue("@ContactName", m.ContactName);
                cmd.Parameters.AddWithValue("@Rank", m.Rank);

                cmd.ExecuteNonQuery();
                conn.Close();
            return ans;
        }
    }
}