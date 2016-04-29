using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace VozaraCarpet.Pages
{
    public partial class Aboutus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(Vozaracoonnection.GetConnectionStringByName());
            SqlCommand cmd = new SqlCommand("Select_About",cnn);
            cmd.Parameters.AddWithValue("@ttype", 0);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sd;
            string sr = "";
            try
            {
                cnn.Open();
                sd = cmd.ExecuteReader();
                if(sd.HasRows)
                    while(sd.Read())
                    {
                        ltrabout.Text = @"<span style='font-size:13px'>"+sd["About"].ToString()+"</span>";
                       
                    }
            }
            catch
            {

            }
            finally
            {
                cnn.Close();
                cmd.Dispose();
            }
            
        }
    }
}