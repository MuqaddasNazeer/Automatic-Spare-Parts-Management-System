using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject.BL
{
    public class StockBL
    {
       private int manufacturerId;
        private int SparePartId;
        private int Quantity;

        public StockBL()
        {
        }

        public StockBL(int manufacturerId, int sparePartId, int quantity)
        {
            this.manufacturerId = manufacturerId;
            SparePartId = sparePartId;
            Quantity = quantity;
        }

        public string AddStock(string con, StockBL sp)
        {
            string ans = "done";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Stock(manufacturerId, SparePart_ID, Quanity) values(@manufacturerId, @SparePart_ID, @Quanity) ", conn);
            cmd.Parameters.AddWithValue("@manufacturerId", sp.manufacturerId);
            cmd.Parameters.AddWithValue("@SparePart_ID", sp.SparePartId);
            cmd.Parameters.AddWithValue("@Quanity", sp.Quantity);
            cmd.ExecuteNonQuery();
            conn.Close();
            return ans;
        }
    }
}