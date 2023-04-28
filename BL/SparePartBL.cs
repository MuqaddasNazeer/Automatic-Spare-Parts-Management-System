using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FinalProject.BL
{
    
    public class SparePartBL
    {
        private string function;
        private string Name;
        private int Length;
        private int Width;
        private int Height;
        private int radius;
        private int price;
        private int ManufactureId;

        public SparePartBL()
        {
        }

        public SparePartBL(string function, string name, int length, int width, int height, int price, int manufactureId)
        {
            this.function = function;
            this.Name = name;
            this.Length = length;
            this.Width = width;
            this.Height = height;
            this.price = price;
            this.ManufactureId = manufactureId;
        }

        public SparePartBL(string function, string name, int radius, int price, int manufactureId)
        {
            this.function = function;
            this.Name = name;
            this.radius = radius;
            this.price = price;
            this.ManufactureId = manufactureId;
        }

        public string AddSparePart_Circular(string con, SparePartBL SP)
        {
            string ans = "done";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO SparePart(Name, [Function] ,ManuacturerId, Length, Height, Width, Radius, Price) values(@Name, @function ,@ManufactureId, @Length, @Height, @Width, @Radius, @Price)", conn);

            cmd.Parameters.AddWithValue("@Name", SP.Name);
            cmd.Parameters.AddWithValue("@function", SP.function);
            cmd.Parameters.AddWithValue("@ManufactureId", SP.ManufactureId);
            cmd.Parameters.AddWithValue("@Length", 0);
            cmd.Parameters.AddWithValue("@Height", 0);
            cmd.Parameters.AddWithValue("@Width", 0);
            cmd.Parameters.AddWithValue("@Radius", SP.radius);
            cmd.Parameters.AddWithValue("@Price", SP.price);
            cmd.ExecuteNonQuery();
            conn.Close();
            return ans;
        }

        public string AddSparePart_Flat(string con, SparePartBL SP)
        {
            string ans = "done";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO SparePart(Name, [Function] ,ManuacturerId, Length, Height, Width, Radius, Price) values(@Name, @function ,@ManuacturerId, @Length, @Height, @Width, @Radius, @Price)", conn);

            cmd.Parameters.AddWithValue("@Name", SP.Name);
            cmd.Parameters.AddWithValue("@function", SP.function);
            cmd.Parameters.AddWithValue("@ManuacturerId", SP.ManufactureId);
            cmd.Parameters.AddWithValue("@Length", SP.Length);
            cmd.Parameters.AddWithValue("@Height", SP.Height);
            cmd.Parameters.AddWithValue("@Width", SP.Width);
            cmd.Parameters.AddWithValue("@Radius", 0);
            cmd.Parameters.AddWithValue("@Price", SP.price);
            cmd.ExecuteNonQuery();
            conn.Close();
            return ans;
        }

        public string DeleteSparePart(string con, String c)
        {
            string ans = "done";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete From SparePart where SparePart.Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", int.Parse(c));
            cmd.ExecuteNonQuery();
            conn.Close();
            return ans;
        }


    }
}