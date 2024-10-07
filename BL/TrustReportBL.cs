using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject.BL
{
    public class TrustReportBL
    {
        private bool ProductNameOrderFulfillment;
        private int Quantity;
        private int ValueOfProducts;
        private float Percentage;
        private int Post_Ship_Payment;
        private int Pre_Ship_Payment;
        private float Rank;
        private int ManufacturerId;

        public TrustReportBL(bool productNameOrderFulfillment, int quantity, int valueOfProducts, float percentage, int post_Ship_Payment, int pre_Ship_Payment, float rank, int manufacturerId)
        {
            ProductNameOrderFulfillment = productNameOrderFulfillment;
            Quantity = quantity;
            ValueOfProducts = valueOfProducts;
            Percentage = percentage;
            Post_Ship_Payment = post_Ship_Payment;
            Pre_Ship_Payment = pre_Ship_Payment;
            Rank = rank;
            ManufacturerId = manufacturerId;
        }
        public static string AddTrustReport(TrustReportBL m, string con)
        {
            string ans = "done";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TrustReport(OrderFulfillment,Quantity,ValueOfProducts,Percentage,Post_Ship_Payment,Pre_Ship_Payment,Rank,ManufacturerId) values(@OrderFulfillment,@Quantity,@ValueOfProducts,@Percentage,@Post_Ship_Payment,@Pre_Ship_Payment,@Rank,@ManufacturerId)", conn);

            cmd.Parameters.AddWithValue("@OrderFulfillment", m.ProductNameOrderFulfillment);
            cmd.Parameters.AddWithValue("@Quantity", m.Quantity);
            cmd.Parameters.AddWithValue("@ValueOfProducts", m.ValueOfProducts);
            cmd.Parameters.AddWithValue("@Percentage", m.Percentage);
            cmd.Parameters.AddWithValue("@Post_Ship_Payment", m.Post_Ship_Payment);
            cmd.Parameters.AddWithValue("@Pre_Ship_Payment", m.Pre_Ship_Payment);
            cmd.Parameters.AddWithValue("@Rank", m.Rank);
            cmd.Parameters.AddWithValue("@ManufacturerId", m.ManufacturerId);
            cmd.ExecuteNonQuery();
            conn.Close();
            return ans;
        }
    }
}