using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRojectCH
{
    public partial class ShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["ChemixId"] == "")
                {
                    Response.Redirect("www.chemixco.com");
                }

                else
                {


                    string strConn = null;
                    strConn = GetConnection.GetConnectionStringByName();
                    SqlConnection conn = new SqlConnection(strConn);
                    SqlCommand cmd = new SqlCommand("Select PageContent from chcms where Id=@Id", conn);
                    SqlDataReader sdr;
                    try
                    {

                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", Request.QueryString["ChemixId"]);
                        cmd.Connection = conn;
                        conn.Open();
                        sdr = cmd.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {
                                ltrContent.Text = sdr["PageContent"].ToString();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                    }
                }
            }
            catch
            {
                Response.Redirect("www.chemixco.com");
            }
        }
    }
}