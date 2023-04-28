using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using FinalProject.BL;

namespace FinalProject
{
    public partial class MaintainStock : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        string s;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool a = ifManufIDExits();
            bool b = ifSparePartIDExits();
            Response.Write("<script>alert('You');</script>");
            if (a == true && b == true) 
            {
                Response.Write("<script>alert('Me.');</script>");
                StockBL c = new StockBL(int.Parse(TextBox2.Text), int.Parse(TextBox1.Text), int.Parse(TextBox9.Text));
                s = c.AddStock(strcon, c);
                Response.Write("<script>alert('Something.');</script>");
            }
            if (s == "done")
            {
                s = "alert(\"done\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", s, true);
                Response.Write("<script>alert('Added Successfully.');</script>");
            }
            else
            {
                Response.Write("<script>alert('NOT Added Successfully.');</script>");

            }

        }

        public bool ifManufIDExits()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT Id from Manufacturer where Id='" + TextBox2.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

        }

        public bool ifSparePartIDExits()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT Id from SparePart where Id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

        }
    }
}


