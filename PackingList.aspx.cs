using FinalProject.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.BL;
using FinalProject.DL;
using System.Data;

namespace FinalProject
{
    public partial class PackingList : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        //int id;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        bool ifcartonExits()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from Carton where [CartonNo.]='" + TextBox4.Text.Trim() + "';", con);
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            //id = int.Parse(TextBox4.Text.Trim());
            if (ifcartonExits())
            {
                SqlConnection con = new SqlConnection(strcon);
                string s = "alert(\"Please wait!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", s, true);
                int cartonid = int.Parse(TextBox4.Text.Trim());
                int weight = int.Parse(TextBox3.Text.Trim());
                int Quantity = int.Parse(TextBox5.Text.Trim());
                PackingListBL p = new PackingListBL(cartonid,Quantity,weight);

                string check = "Not updated";
                Response.Write("<script>alert('" + check + "');</script>");
                check = PackingListBL.AddPackingListBL(p,strcon);
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