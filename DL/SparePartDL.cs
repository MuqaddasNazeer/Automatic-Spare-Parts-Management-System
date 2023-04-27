using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace FinalProject.DL
{
    public class SparePartDL
    {
        public SparePartDL()
        {
        }

        public ListBox view(ListBox g)
        {
          //  ListBox g;
            SqlConnection cont = new SqlConnection("Data Source=DESKTOP-OLK9GL6;Initial Catalog =SparePartsManagment;Integrated Security=True");
            SqlDataReader Reader;
            SqlCommand cmd;
            cmd = new SqlCommand();
            cont.Open();
            cmd.Connection.Open();
            cmd.CommandText = "select * from Manufacturer";
            Reader = cmd.ExecuteReader();
            while(Reader.Read())
            {
                g.Items.Add((ListItem)Reader["ManufatureId"]);
            }
            cont.Close();
            return g;
        }

    }

    

}