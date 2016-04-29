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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
            SqlCommand cmd = new SqlCommand("Insert_Login", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", "danlopmatt");
            Guid uniquecode;
            uniquecode = Guid.NewGuid();
            cmd.Parameters.AddWithValue("@uidentity", uniquecode);

            string pass = "moghadamco@2";
            string uniqpass = pass + uniquecode.ToString();
            VozaraCarpet.hashpassword hash_obj = new hashpassword();

            string temphashpass = hashpassword.CreateHash(uniqpass);
            cmd.Parameters.AddWithValue("@pass", temphashpass);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }
        }
        protected string GetUser_IP()
        {
            string VisitorsIPAddr = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
            }
            return VisitorsIPAddr.ToString();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (txtuser.Text.Trim() == "" || txtpass.Text.Trim() == "")
            {
                lblmsg.Text = "لطفا نام کاربری و رمز عبور خود را وارد نمایید";
            }
            else
            {
                string teststr = hashpassword.CreateHash(txtpass.Text.Trim());
                SqlConnection cnn = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
                SqlCommand cmd = new SqlCommand("SELECT Id ,pass , uidentity from Tbl_Login  where username=@user", cnn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@user", txtuser.Text.Trim());

                SqlDataReader dr;
                try
                {
                    cnn.Open();
                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            bool tr = hashpassword.ValidatePassword(txtpass.Text.Trim() + dr["uidentity"].ToString(), dr["pass"].ToString());
                            if (tr)
                            {
                                //publicRelation.hashpassword hash_obj = new hashpassword();
                                string ipid = GetUser_IP() + dr["Id"].ToString();
                                string temphashipid = hashpassword.CreateHash(ipid);
                                Session["hashipid"] = temphashipid;
                                Session["Id"] = dr["Id"].ToString();
                                Response.Redirect("AdminDanlop/homeadmin.aspx");
                                //lblmsg.Text = "یافت شد"; 
                            }

                            else
                            {
                                lblmsg.Text = "کاربر مورد نظر یافت نشد";
                            }

                        }

                    }

                }
                catch (Exception ex)
                {
                    lblmsg.Text = "No ";
                }
                finally
                {
                    cnn.Close();
                    cmd.Dispose();
                }
            }
        }
    }
}