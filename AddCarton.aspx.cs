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
    public partial class AddCarton : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('BTS.');</script>");

            if (TextBox2.Text.Trim().Length > 0 )
            {
                Response.Write("<script>alert('Taehyung.');</script>");

                AddCartonBL c = new AddCartonBL(TextBox2.Text);
                string b = c.AddCartonNo(strcon, c);
                if (b == "done")
                {
                    b = "alert(\"done\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", b, true);
                    Response.Write("<script>alert('Added Successfully.');</script>");
                }
                else
                {
                    Response.Write("<script>alert('NOT Added Successfully.');</script>");

                }
            }
        }
    }
}