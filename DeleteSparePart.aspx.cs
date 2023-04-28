using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.BL;
namespace FinalProject
{
    public partial class DeleteSparePart : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string c;
            SparePartBL d = new SparePartBL();
            Response.Write("<script>alert('2');</script>");

            if (TextBox1.Text.Trim().Length != 0)
            {
                Response.Write("<script>alert('1');</script>");

                c = d.DeleteSparePart(strcon, TextBox1.Text);
                if(c == "done")
                {
                    c = "alert(\"done\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", c, true);
                    Response.Write("<script>alert('Deleted Successfully.');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Cannot Delete');</script>");

                }


            }
        }
    }
}