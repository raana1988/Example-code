using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VozaraCarpet.Pages
{
    public partial class EnterUser : System.Web.UI.Page
    {
        int temp = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] != null)
                {
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    // Response.Redirect("enteruser.aspx");

                }
            }
            catch
            {
            }
        }

        protected void btnenter_Click(object sender, EventArgs e)
        {

            if (txtuser.Text.Trim() == "" || txtpass.Text.Trim() == "")
            {
                lblmsg.Text = "لطفا نام کاربری و رمز عبور خود را وارد نمایید ";
            }
            else
            {
                bool flag = true;
                SqlConnection cnn = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
                SqlCommand cmd = new SqlCommand("select Id , UserName ,  Password from Tbl_UserSubmit where UserName='" + txtuser.Text + "' AND Password='" + txtpass.Text + "'", cnn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr;
                try
                {
                    cnn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Session["userid"] = dr["Id"].ToString();
                            temp = Convert.ToInt32(Session["userid"].ToString());
                        }
                        flag = false;
                    }
                    else
                    {
                        lblmsg.Text = "نام کاربری یا رمز عبور اشتباه است .";
                    }

                }
                catch
                {
                    lblmsg.Text = "no";

                }
                finally
                {
                    cnn.Close();
                    cmd.Dispose();

                    if (flag == false)
                    {
                        bool check_url = true;
                        writecookies();
                        string st = "";
                        try
                        {
                            st = Request.QueryString["From"];

                            st = st.Substring(1, (st.Length) - 1);
                            check_url = false;
                            if (st.ToLower() == "pages/enteruser.aspx")
                            {
                                check_url = true;
                            }
                            //Response.Redirect(st);
                        }
                        catch (Exception ex)
                        {
                            Response.Redirect("Homepage.aspx");
                        }
                        if (!check_url)
                        {

                            Response.Redirect("../"+st);
                        }
                        else
                        {
                            Response.Redirect("Homepage.aspx");
                        }

                    }
                }
            }

        }
        protected void writecookies()
        {
            try
            {
                //Grab the cookie
                HttpCookie cookie = Request.Cookies["user"];

                //Check to make sure the cookie exists
                if (cookie == null)
                {
                    HttpCookie cookie2 = new HttpCookie("user");
                    
                    cookie2.Value = txtuser.Text + "-" + Encrypt(temp.ToString());

                    cookie2.Expires = DateTime.Now.AddDays(20);
                    //Add the cookie
                    Response.Cookies.Add(cookie2);
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddDays(-1d);

                    string str = cookie.Value.ToString();
                   
                    cookie.Value = txtuser.Text + "-" + Encrypt(temp.ToString());
                   
                    cookie.Expires = DateTime.Now.AddDays(20);
                    //Add the cookie
                    Response.Cookies.Add(cookie);
                    //Write the cookie value
                }

            }
            catch
            {
                HttpCookie cookie2 = new HttpCookie("user");
                
                cookie2.Value = txtuser.Text + "-" + Encrypt(temp.ToString());
                
                cookie2.Expires = DateTime.Now.AddDays(20);
                //Add the cookie
                Response.Cookies.Add(cookie2);
            }
        }
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}