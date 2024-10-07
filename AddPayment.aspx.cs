using FinalProject.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class AddPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

       
        protected void Button3_Click(object sender, EventArgs e)
        {
            //   if (ifuserExits())
            //   {
            if (ifOrderExists())
            {
                SqlConnection con = new SqlConnection(strcon);
                string s = "alert(\"Please wait!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", s, true);
                int orderNo = int.Parse(TextBox4.Text.Trim());
                int AccountNo = int.Parse(TextBox3.Text.Trim());
                string PAYMENTtYPE = DropDownList1.Text.Trim();

                AddPaymentBL manu = new AddPaymentBL(AccountNo, orderNo, PAYMENTtYPE);

                string check = "Not updated";
                Response.Write("<script>alert('" + check + "');</script>");
                check = AddPaymentBL.AddPayment(manu, strcon);
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
                Response.Write("<script>alert('No  order Exixts!!! Enter Correct Id.');</script>");

            }
            //    }
            //    else
            //     {
            //         Response.Write("<script>alert('No user  Exixts!!! Enter Correct Id.');</script>");

            //     }

        }

        bool ifuserExits()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * from Login where Id='" + TextBox3.Text.Trim() + "';", con);
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