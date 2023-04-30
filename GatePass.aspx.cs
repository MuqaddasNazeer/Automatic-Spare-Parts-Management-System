using FinalProject.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class GatePass : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            bool isDefected = false;
            bool isMissing = false;
            if (ifOrderExists())
            {
                SqlConnection con = new SqlConnection(strcon);
                string s = "alert(\"Please wait!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", s, true);
                string prodName = TextBox3.Text.Trim();
                if (Request.Form["defected"] == "true")
                {
                    isDefected = true;
                }
                else if (Request.Form["defected"] == "false")
                {
                    isDefected = false;
                }
                if (Request.Form["missing"] == "true")
                {
                    isMissing = true;
                }
                else
                {
                    isMissing = false;
                }
                int quantity = int.Parse(TextBox1.Text.Trim());
                int OrderID = int.Parse(TextBox4.Text.Trim());
                GatePassBL p = new GatePassBL(prodName, OrderID, quantity, isMissing, isDefected);

                string check = "Not updated";
                Response.Write("<script>alert('" + check + "');</script>");
                check = GatePassBL.AddGatePass(p, strcon);
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
                Response.Write("<script>alert('No Order Exixts!!! Enter Correct Order no.');</script>");


            }
        }

        bool ifOrderExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from PlaceOrder where Id ='" + TextBox4.Text.Trim() + "';", con);
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