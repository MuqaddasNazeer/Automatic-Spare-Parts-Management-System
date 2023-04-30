using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject.BL
{
    public class AddCartonBL
    {
       // private int CartonNo;
        private string ProductName;

        public AddCartonBL()
        {
        }

        public AddCartonBL(string productName)
        {
           // this.CartonNo = cartonNo;
            this.ProductName = productName;
        }

        public string AddCartonNo(string con, AddCartonBL c )
        {
            string ans = "done";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Carton (ProdsuctsName) values( @ProductsName )", conn);

            //cmd.Parameters.AddWithValue("@CartonNo", c.CartonNo);
            cmd.Parameters.AddWithValue("@ProductsName", c.ProductName);
            cmd.ExecuteNonQuery();
            conn.Close();
            return ans;
        }
    }
}