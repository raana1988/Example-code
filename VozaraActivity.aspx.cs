using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VozaraCarpet.Pages
{
    public partial class VozaraActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(Vozaracoonnection.GetConnectionStringByName());
            SqlCommand cmd = new SqlCommand("Select_About", cnn);
            cmd.Parameters.AddWithValue("@ttype", 5);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sd;
            string sr = "";
            try
            {
                cnn.Open();
                sd = cmd.ExecuteReader();
                if (sd.HasRows)
                    while (sd.Read())
                    {
                        ltrabout1.Text = @"<span style='font-size:13px'>" + sd["About"].ToString() + "</span>";

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