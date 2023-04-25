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
using System.Net;

namespace FinalProject
{
    public partial class AddManufacturer : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            string s = "alert(\"Please wait!\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", s, true);
            string Address = TextBox1.Text.Trim();
            string BusinessName = TextBox2.Text.Trim();
            string JobTitle = TextBox3.Text.Trim();
            string ContactName = TextBox3.Text.Trim();
            float Rank = float.Parse(TextBox4.Text.Trim());
            Manufacturer manu = new Manufacturer(Address,BusinessName,JobTitle,ContactName,Rank);

            string check = "Not updated";
            Response.Write("<script>alert('" + check + "');</script>");
            check = Manufacturer.AddManufacturer(manu, strcon);
            Response.Write("<script>alert('" + check + "');</script>");
            Response.Write("<script>alert('we are back ');</script>");
            if (check == "done")
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
        bool ifManufExits()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from Manufacturer where Address='" + TextBox2.Text.Trim() + "' AND BusinessName='" + TextBox1.Text.Trim() + "'  AND JobTitle='" + TextBox5.Text.Trim() + "'  AND ContactName='" + TextBox3.Text.Trim() + "'  AND Rank='" + TextBox4.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter();
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
        /*void addNewManufacturer()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Manufacturer(Address,BusinessName,JobTitle,ContactName,Rank) values(@Address,@BusinessName,@JobTitle,@ContactName,@Rank)", con);

                cmd.Parameters.AddWithValue("@BusinessName", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@JobTitle", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactName", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@Rank", TextBox4.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Manufacturer added Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            void clearForm()
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
            }
        }
        */
    }
}