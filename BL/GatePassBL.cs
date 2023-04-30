using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject.BL
{

    public class GatePassBL
    {
        private string ProductName;
        private int OrderId;
        private int Quantity;
        private bool Missing;
        private bool Defected;

        public GatePassBL(string productName, int orderId, int quantity, bool missing, bool defected)
        {
            ProductName = productName;
            OrderId = orderId;
            Quantity = quantity;
            Missing = missing;
            Defected = defected;
        }
        public static string AddGatePass(GatePassBL m, string con)
        {
            string ans = "done";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO GatePass(OrderId,ProductName,Qunatity,Missing,Defected,[Date/Time]) values(@OrderId,@ProductName,@Qunatity,@Missing,@Defected,@DateTime)", conn);

            cmd.Parameters.AddWithValue("@OrderId", m.OrderId);
            cmd.Parameters.AddWithValue("@ProductName", m.ProductName);
            cmd.Parameters.AddWithValue("@Qunatity", m.Quantity);
            cmd.Parameters.AddWithValue("@Missing", m.Missing);
            cmd.Parameters.AddWithValue("@Defected", m.Defected);
            cmd.Parameters.AddWithValue("@DateTime", DateTime.Today.ToString());
            cmd.ExecuteNonQuery();
            conn.Close();
            return ans;
        }


    }
}