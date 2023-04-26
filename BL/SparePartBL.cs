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

        public static string AddSparePart_Circular(string con, SparePartBL SP)
        {
            string ans = "done";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO SparePart(Name, Function ,ManufactureId, Length, Height, Width, Radius, Price) values(@Name, @Function ,@ManufactureId, @Length, @Height, @Width, @Radius, @Price)", conn);

            cmd.Parameters.AddWithValue("@Name", SP.Name);
            cmd.Parameters.AddWithValue("@Function", SP.function);
            cmd.Parameters.AddWithValue("@ManufactureId", SP.ManufactureId);
            cmd.Parameters.AddWithValue("@Length", null);
            cmd.Parameters.AddWithValue("@Height", null);
            cmd.Parameters.AddWithValue("@Width", null);
            cmd.Parameters.AddWithValue("@Radius", SP.radius);
            cmd.Parameters.AddWithValue("@Price", SP.price);
            cmd.ExecuteNonQuery();
            conn.Close();
            return ans;
        }

        public static string AddSparePart_Flat(string con, SparePartBL SP)
        {
            string ans = "done";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO SparePart(Name, Function ,ManufactureId, Length, Height, Width, Radius, Price) values(@Name, @Function ,@ManufactureId, @Length, @Height, @Width, @Radius, @Price)", conn);

            cmd.Parameters.AddWithValue("@Name", SP.Name);
            cmd.Parameters.AddWithValue("@Function", SP.function);
            cmd.Parameters.AddWithValue("@ManufactureId", SP.ManufactureId);
            cmd.Parameters.AddWithValue("@Length", SP.Length);
            cmd.Parameters.AddWithValue("@Height", SP.Height);
            cmd.Parameters.AddWithValue("@Width", SP.Width);
            cmd.Parameters.AddWithValue("@Radius", null);
            cmd.Parameters.AddWithValue("@Price", SP.price);
            cmd.ExecuteNonQuery();
            conn.Close();
            return ans;
        }


    }
}