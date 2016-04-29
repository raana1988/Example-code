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
    public partial class AboutFarsi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LiteralAboutUs.Text = Server.HtmlDecode(SelectDescription());
        }
         public string SelectDescription()
        {
            string str = null;
            string strConn = null;
            strConn =GetConnection.GetConnectionStringByName();

            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                string query = "SELECT [Desc] FROM [dbo].[About] Where elanguage=2";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader sdr;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        str = Server.HtmlDecode(sdr["Desc"].ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                string st = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return str;

        }
    }

    }
