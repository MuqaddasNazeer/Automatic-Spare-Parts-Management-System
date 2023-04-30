using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject.BL
{
    public class PackingListBL
    {
        private int CartonNo;
        private int quantity;
        private int weight;

        public PackingListBL(int cartonNo, int quantity, int weight)
        {
            this.CartonNo = cartonNo;
            this.quantity = quantity;
            this.weight = weight;
        }
        public static string AddPackingListBL(PackingListBL p, string con)
        {
            string ans = "done";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO PackingList([CartonNo],[PackingDate],[Quantity],[Weight]) values(@CartonNo,@PackingDate,@Quantity,@Weight)", conn);

            cmd.Parameters.AddWithValue("@CartonNo", p.CartonNo);
            cmd.Parameters.AddWithValue("@PackingDate", DateTime.Today.ToString());
            cmd.Parameters.AddWithValue("@Quantity", p.quantity);
            cmd.Parameters.AddWithValue("@Weight", p.weight);

            cmd.ExecuteNonQuery();
            conn.Close();
            return ans;
        }
    }
}