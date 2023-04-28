using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.BL;
using System.Configuration;

namespace FinalProject
{
    public partial class PlaceOrder : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

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

                SqlCommand cmd = new SqlCommand("SELECT * from Manufacturer where Id='" + TextBox4.Text.Trim() + "';", con);
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (ifManufExits())
            {
                SqlConnection con = new SqlConnection(strcon);
                string s = "alert(\"Please wait!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", s, true);
                string Dimension = DropDownList1.Text.Trim();
                string Material = TextBox2.Text.Trim(); ;
                int manuID = int.Parse(TextBox4.Text.Trim());
                PlaceOrderBL p = new PlaceOrderBL(manuID, Dimension, Material);

                string check = "Not updated";
                Response.Write("<script>alert('" + check + "');</script>");
                check = PlaceOrderBL.addPlaceOrder(p, strcon);
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
            else
            {
                Response.Write("<script>alert('No Manufacturer Exixts!!! Enter Correct Id.');</script>");


            }
        }
    }
}