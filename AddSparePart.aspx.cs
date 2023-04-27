using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.DL;
using FinalProject.BL;
using System.Collections.Specialized;
using System.EnterpriseServices.CompensatingResourceManager;

namespace FinalProject
{
    public partial class AddSparePart : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        string c = null;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            bool a = ifManufIDExits();
            string value = DropDownList1.Text.Trim();
            Response.Write("<script>alert('" + value + "');</script>");

            if (a == true)
            {
                Response.Write("<script>alert('value34');</script>");
                if (value == "2")
                {
                    Response.Write("<script>alert('Value1.');</script>");
                    SparePartBL sp = new SparePartBL(TextBox2.Text, TextBox1.Text, int.Parse(TextBox3.Text), int.Parse(TextBox6.Text), int.Parse(TextBox5.Text), int.Parse(TextBox4.Text), int.Parse(TextBox8.Text));
                     c = sp.AddSparePart_Flat(strcon, sp);
                }
                else if (value == "1")
                {
                    Response.Write("<script>alert('Value3.');</script>");
                    SparePartBL sp = new SparePartBL(TextBox2.Text, TextBox1.Text, int.Parse(TextBox3.Text), int.Parse(TextBox4.Text), int.Parse(TextBox8.Text));
                    c = sp.AddSparePart_Circular(strcon, sp);
                }

                if (c == "done")
                {
                    c = "alert(\"done\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", c, true);
                    Response.Write("<script>alert('Added Successfully.');</script>");
                }
                else
                {
                    Response.Write("<script>alert('NOT Added Successfully.');</script>");

                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

                SqlCommand cmd = new SqlCommand("SELECT Id from Manufacturer where Id='" + TextBox8.Text.Trim() + "';", con);
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