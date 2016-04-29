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
    public partial class product_detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                if (Request.QueryString["product"].Length > 0)
                {
                    id = Convert.ToInt32(Request.QueryString["product"]);
                }
                string strConn = null;
                strConn = GetConnection.GetConnectionStringByName();
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("select DataSheetUrl,TitlePr,InfoPr from chproduct where ID=@ID", conn);
                SqlDataReader sdr;
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Connection = conn;
                    conn.Open();
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            if (sdr["DataSheetUrl"].ToString() == "-1")
                            {
                                dataSheetDowloadLink.Visible = false;
                            }
                            else
                            {
                                dataSheetDowloadLink.Visible = true;
                                dataSheetDowloadLink.Text = "download datasheet";
                                dataSheetDowloadLink.NavigateUrl = "DataSheet/" + sdr["DataSheetUrl"].ToString();
                            }
                            lblTitle.Text = sdr["TitlePr"].ToString();
                            ltrContent.Text = sdr["InfoPr"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ltrContent.Text = ex.Message;
                }
            }
            catch
            {
                Response.Redirect("ugc.aspx");
            }


        }
    }
}