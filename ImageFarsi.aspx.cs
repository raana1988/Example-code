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
    public partial class ImageFarsi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LiteralImages.Text = TextLiteral();
        }
        protected string TextLiteral()
        {
            string str = "";
            string strConn = null;
            strConn =GetConnection.GetConnectionStringByName();
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                string query = "select * from tbl_Image where AlbumID=@AlbumID";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader sdr;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@AlbumID", Request.QueryString["AlbumID"].ToString());
                conn.Open();
                sdr = cmd.ExecuteReader();

                string name_temp;
                if (sdr.HasRows)
                {
                   
                    while (sdr.Read())
                    {
                        name_temp = sdr["ImageName"].ToString();
                        string thumb = sdr["Thumb"].ToString();
                        string temp_image_url = sdr["ImageUrl"].ToString();
                        if (temp_image_url == "")
                            temp_image_url = "/image/";
                        string[] array = new string[2];
                        str += "<div style='width:200px;height:170px;overflow:hidden;float:left;border:#CCC double thick; border-radius:10px;margin-left:65px;margin-bottom:50px'> <a class=\"vlightbox1\" href='" + temp_image_url + "' style='' title='"+name_temp+"'> <img src='" + thumb + "' style='opacity: 1;' /> </a></div>";
                     
                    }
                }
            }
            catch (Exception ex)
            {
                string stri = ex.Message;
                Response.Redirect("AlbumFarsi.aspx");
            }
            finally
            {
                conn.Close();
            }

            return str;

        }

        public string Thumb { get; set; }
    }
    
}