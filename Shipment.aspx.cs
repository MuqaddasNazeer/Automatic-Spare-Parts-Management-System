using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.BL;

namespace FinalProject
{
    public partial class Shipment : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        bool ifListIDExits()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from PackingList where Id='" + TextBox5.Text.Trim() + "';", con);
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
            if (ifListIDExits())
            {
                SqlConnection con = new SqlConnection(strcon);
                string s = "alert(\"Please wait!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", s, true);
                string containerNO = (TextBox1.Text.Trim());
                string sealNO = (TextBox2.Text.Trim());
                string vehicleNO = (TextBox3.Text.Trim());
                int id = int.Parse(TextBox5.Text.Trim());
                int Volume = int.Parse(TextBox4.Text.Trim());
                ShipmentBL ship = new ShipmentBL(containerNO,sealNO,vehicleNO,id,Volume);

                string check = "Not updated";
                Response.Write("<script>alert('" + check + "');</script>");
                check = ShipmentBL.goForShipment(ship, strcon);
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