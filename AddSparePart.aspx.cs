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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections.Specialized;
using System.EnterpriseServices.CompensatingResourceManager;
using CrystalDecisions.Web;

namespace FinalProject
{
    public partial class AddSparePart : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        string c = null;
        //ReportDocument crystalReport = new ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            bool a = ifManufIDExits();
            string value = DropDownList1.Text.Trim();
            Response.Write("<script>alert('" + value + "');</script>");

            if (TextBox1.Text.Trim().Length > 1 && TextBox2.Text.Trim().Length > 1 && TextBox4.Text.Trim().Length > 1 && TextBox7.Text.Trim().Length > 1 && TextBox8.Text.Trim().Length > 1)
            {

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
                else
                {
                    Response.Write("<script>alert('Wrong Input');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Incomplete Input');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0OSO5EO;Initial Catalog =SparePartsManagment2;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from SparePart",con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            ReportDocument crp = new ReportDocument();
            crp.Load(Server.MapPath("SparePart.rpt"));
            crp.SetDataSource(ds.Tables["tables"]);
            CrystalReportViewer1.ReportSource= crp;
            crp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Spare Part info");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteSparePart.aspx");
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