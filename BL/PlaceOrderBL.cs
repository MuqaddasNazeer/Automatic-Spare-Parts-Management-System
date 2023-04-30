using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject.BL
{
    public class PlaceOrderBL
    {
        [Key] public int ID { get; set; }
        private int ManufacturerId;
        private string Dimension;
        private string Material;


        public static string addPlaceOrder(PlaceOrderBL placeOrder, string con)
        {
            string id;
            /*string ans = "done";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO PlaceOrder(ManufacturerId,Dimension,Material) values(@ManufacturerId,@Dimension,@Material)", conn);
            cmd.Parameters.AddWithValue("@ManufacturerId", placeOrder.ManufacturerId);
            cmd.Parameters.AddWithValue("@Dimension", placeOrder.Dimension);
            cmd.Parameters.AddWithValue("@Material", placeOrder.Material);
            cmd.ExecuteNonQuery();
            conn.Close();
            return ans;*/
            string ans = "done";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO PlaceOrder(ManufacturerId,Dimension,Material) values(@ManufacturerId,@Dimension,@Material)", conn);
            cmd.Parameters.AddWithValue("@ManufacturerId", placeOrder.ManufacturerId);
            cmd.Parameters.AddWithValue("@Dimension", placeOrder.Dimension);
            cmd.Parameters.AddWithValue("@Material", placeOrder.Material);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("Select @@identity as 'Identity'", conn);
            id = cmd.ExecuteScalar().ToString();
            conn.Close();

            SqlConnection conn1 = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("INSERT INTO [Order]([OrderNo.],[OrderDate],OrderStatus,Price,Discount,ExpectedDate,PostedOrNot) values(@id,@OrderDate,@OrderStatus,cast((SELECT SUM(s.Price) FROM SparePart s join Manufacturer m ON m.Id = s.ManuacturerId JOIN PlaceOrder p ON m.Id = p.ManufacturerId JOIN [Order] o ON o.[OrderNo.] = p.Id) as float),@Discount,@ExpectedDate,@PostedOrNot)", conn);
            cmd1.Parameters.AddWithValue("@id", id);
            cmd1.Parameters.AddWithValue("@OrderDate", DateTime.Today.ToString());
            cmd1.Parameters.AddWithValue("@OrderStatus", "Waiting");
            //  cmd1.Parameters.AddWithValue("@Price", 4.4f);

            //  cmd1.Parameters.AddWithValue("@Price", "Select cast(SELECT SUM(s.Price) FROM SparePart s join Manufacturer m ON m.Id = s.ManuacturerId JOIN PlaceOrder p ON m.Id = p.ManufacturerId JOIN [Order] o ON o.[OrderNo.] = p.Id) as float ");
            cmd1.Parameters.AddWithValue("@Discount", 0.0f);
            cmd1.Parameters.AddWithValue("@ExpectedDate", DateTime.Now.AddDays(2));
            cmd1.Parameters.AddWithValue("@PostedOrNot", false);
            cmd1.ExecuteNonQuery();
            conn1.Close();
            return ans;


        }
        public PlaceOrderBL() { }

        public PlaceOrderBL(int manufacturerId, string dimension, string material)
        {
            ManufacturerId = manufacturerId;
            Dimension = dimension;
            Material = material;
        }
    }
}