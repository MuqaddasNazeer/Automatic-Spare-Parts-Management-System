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

            cmd.Parameters.AddWithValue("ManufacturerID", placeOrder.ManufacturerId);
            cmd.Parameters.AddWithValue("@Dimension", placeOrder.Dimension);
            cmd.Parameters.AddWithValue("@Material", placeOrder.Material);

            cmd.ExecuteNonQuery();
            conn.Close();
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