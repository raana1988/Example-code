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
    public partial class InformationBuyer : System.Web.UI.Page
    {
        string buyername;
        Dictionary<int, string> dicminen = new Dictionary<int, string>();
        Dictionary<int, string> dicpro = new Dictionary<int, string>();
        Dictionary<int, string> dicprice = new Dictionary<int, string>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtaddress.Text.Trim() == "" || txtmail.Text.Trim() == "" || txtmob.Text.Trim() == "" || txtname.Text.Trim() == "" || txtpostcode.Text.Trim() == "")
            {
                lblmsg.Text = "لطفا اطلاعات خواسته شده را کامل نمایید.";
            }
            else
            {
                SqlConnection cnn = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
                SqlCommand cmd = new SqlCommand("Insert_Buyer", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@email", txtmail.Text);
                cmd.Parameters.AddWithValue("@mobile", txtmob.Text);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@postcode", txtpostcode.Text);
                
                SqlDataReader dr;
                bool flag = true;
                try
                {
                    cnn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            Session["user"] = dr["Id"].ToString();
                        }
                    lblmsg.Text = "کاربر با موفقیت در سیستم ثبت شد";
                    flag = false;
                    //Response.Redirect("productgroup.aspx");
                }
                catch (Exception ex)
                {
                    lblmsg.Text = "متاسفانه خطایی رخ داده است ";
                }
                finally
                {
                    cnn.Close();
                    cmd.Dispose();
                    if (flag == false)
                    {
                        Response.Redirect("beforeFactor.aspx");
                    }
                }
            }
        }
        protected void writecookies(int temp, string user)
        {
            try
            {
                //Grab the cookie
                HttpCookie cookie = Request.Cookies["user"];
                //Check to make sure the cookie exists
                if (cookie == null)
                {
                    HttpCookie cookie2 = new HttpCookie("user");
                    
                    cookie2.Value = user + "-" + Encrypt(temp.ToString());

                    cookie2.Expires = DateTime.Now.AddDays(20);
                    //Add the cookie
                    Response.Cookies.Add(cookie2);
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddDays(-1d);

                    string str = cookie.Value.ToString();
                    
                    cookie.Value = user + "-" + Encrypt(temp.ToString());
                    
                    cookie.Expires = DateTime.Now.AddDays(20);
                    //Add the cookie
                    Response.Cookies.Add(cookie);
                    //Write the cookie value
                }

            }
            catch
            {
                HttpCookie cookie2 = new HttpCookie("user");
               
                cookie2.Value = user + "-" + Encrypt(temp.ToString());
               
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
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (txtadd.Text.Trim() == "" || txtmail1.Text.Trim() == "" || txtphone.Text.Trim() == "" || txtnm.Text.Trim() == "" || txtpass1.Text.Trim() == "" || txtuser1.Text.Trim() == "" || txtposti.Text.Trim() == "" || txtrepeat.Text.Trim() == "")
            {
                lblmsg1.Text = "لطفا اطلاعات خواسته شده را کامل نمایید.";
            }
            else if (txtpass1.Text != txtrepeat.Text)
            {
                lblmsg1.Text = "تکرار کلمه عبور اشتباه است";
            }
            else
            {
                SqlConnection cnn = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
                SqlCommand cmd = new SqlCommand("Insert_UserSubmit", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtnm.Text);
                cmd.Parameters.AddWithValue("@username", txtuser1.Text);
                cmd.Parameters.AddWithValue("@password", txtpass1.Text);
                cmd.Parameters.AddWithValue("@email", txtmail1.Text);
                cmd.Parameters.AddWithValue("@mobile", txtphone.Text);
                cmd.Parameters.AddWithValue("@address", txtadd.Text);
                cmd.Parameters.AddWithValue("@postcode", txtposti.Text);
                cmd.Parameters.AddWithValue("@captcha", "aaaa");
                SqlDataReader dr;
                bool flagg = true;
                try
                {
                    cnn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            Session["userid"] = dr["Id"].ToString();

                        }
                    writecookies(Convert.ToInt32(Session["userid"]), txtuser1.Text);
                    lblmsg1.Text = "کاربر با موفقیت در سیستم ثبت شد";
                    flagg = false;
                    //Response.Redirect("productgroup.aspx");
                }
                catch (Exception ex)
                {
                    lblmsg1.Text = "متاسفانه خطایی رخ داده است ";
                }
                finally
                {
                    cnn.Close();
                    cmd.Dispose();
                    if (flagg == false)
                    {
                        prodimenname();
                        ReadCookie();
                        inserttodatabase();
                        Response.Redirect("beforeFactor.aspx");
                    }
                }
            }
        }
        protected void prodimenname()
        {
            SqlConnection cnn = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
            SqlCommand cmd = new SqlCommand("select Id, Dimension from Tbl_DemensionPrice", cnn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr;
            try
            {
                cnn.Open();
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                    while (dr.Read())
                    {
                        int iddimen = Convert.ToInt32(dr["Id"].ToString());
                        string dimension_name = dr["Dimension"].ToString();
                        dicminen.Add(iddimen, dimension_name);
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
            SqlConnection cnn1 = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
            SqlCommand cmd1 = new SqlCommand("select Id, ProductName from Tbl_Product", cnn1);
            cmd1.CommandType = CommandType.Text;
            SqlDataReader dr1;
            try
            {
                cnn1.Open();
                dr1 = cmd1.ExecuteReader();

                if (dr1.HasRows)
                    while (dr1.Read())
                    {
                        int idpro = Convert.ToInt32(dr1["Id"].ToString());
                        string pro_name = dr1["ProductName"].ToString();
                        dicpro.Add(idpro, pro_name);
                    }
            }
            catch
            {

            }
            finally
            {
                cnn1.Close();
                cmd1.Dispose();
            }
            SqlConnection cnn2 = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
            SqlCommand cmd2 = new SqlCommand("select Id, Price from Tbl_Product", cnn2);
            cmd2.CommandType = CommandType.Text;
            SqlDataReader dr2;
            try
            {
                cnn2.Open();
                dr2 = cmd2.ExecuteReader();

                if (dr2.HasRows)
                    while (dr2.Read())
                    {
                        int idp = Convert.ToInt32(dr2["Id"].ToString());
                        string price_name = dr2["Price"].ToString();
                        dicprice.Add(idp, price_name);
                    }
            }
            catch
            {

            }
            finally
            {
                cnn2.Close();
                cmd2.Dispose();
            }
        }
        protected void ReadCookie()
        {
            DataTable dt = new DataTable();
            DataColumn cl1 = new DataColumn();
            cl1.ColumnName = "کد محصول";
            dt.Columns.Add(cl1);
            DataColumn cl2 = new DataColumn();
            cl2.ColumnName = "نام محصول";
            dt.Columns.Add(cl2);
            DataColumn cl3 = new DataColumn();
            cl3.ColumnName = "رنگ";
            dt.Columns.Add(cl3);
            DataColumn cl = new DataColumn();
            cl.ColumnName = "تعداد";
            dt.Columns.Add(cl);
            DataColumn cl4 = new DataColumn();
            cl4.ColumnName = "قیمت";
            dt.Columns.Add(cl4);

            //Get the cookie name the user entered
            //String strCookieName = Request.QueryString["danlopco"].ToString();
            //Grab the cookie
            HttpCookie cookie = Request.Cookies["vozara"];
            //Check to make sure the cookie exists
            if (cookie == null)
            {
                //lblCookie.Text = "Cookie not found. <br><hr>";
            }
            else
            {
                //Write the cookie value
                String strCookieValue = cookie.Value.ToString();
                if (strCookieValue == string.Empty)
                {

                }
                else
                {
                    string[] stunderline = strCookieValue.Split('_');
                    foreach (string stunderline_values in stunderline)
                    {
                        string[] stdash = stunderline_values.Split('-');
                        dt.Rows.Add(stdash[0], dicpro[Convert.ToInt32(stdash[2])], dicminen[Convert.ToInt32(stdash[0])], stdash[1], dicprice[Convert.ToInt32(stdash[0])]);

                    }
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                    //lblCookie.Text = strCookieValue + "</b><br><hr>";
                }
            }
        }
        private Dictionary<int, int> getproId()
        {
            Dictionary<int, int> product_dimension_dic = new Dictionary<int, int>();
            SqlConnection co = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
            SqlCommand cm = new SqlCommand("select  Id , ProductCode from Tbl_Product", co);
            SqlDataReader rd;
            try
            {
                co.Open();
                rd = cm.ExecuteReader();
                if (rd.HasRows)
                    while (rd.Read())
                    {
                        product_dimension_dic.Add(Convert.ToInt32(rd["Id"]), Convert.ToInt32(rd["ProductCode"]));

                    }
                //Response.Cookies["danlopco"].Expires = DateTime.Now.AddDays(-1);
            }
            catch
            {

            }
            finally
            {
                co.Close();
                cm.Dispose();
            }
            return product_dimension_dic;

        }
        protected void inserttodatabase()
        {
            Dictionary<int, int> product_dimension_dic_temp = new Dictionary<int, int>();
            product_dimension_dic_temp = getproId();
            foreach (GridViewRow row2 in GridView2.Rows)
            {
                Label price = row2.FindControl("lblPriceId") as Label;
                Label productcode = row2.FindControl("lblProductid") as Label;
                Label dimension = row2.FindControl("lblcolor") as Label;
                Label no = row2.FindControl("lblNo") as Label;
                SqlConnection co = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
                SqlCommand cm = new SqlCommand("insert into Tbl_Buy(PriceId, ColorId,No,UserId,ProductId) values(@price,@color,@no,@userid,@productcode) ", co);
                cm.CommandType = CommandType.Text;
                cm.Parameters.AddWithValue("@price", price.Text);
                cm.Parameters.AddWithValue("@productcode", product_dimension_dic_temp[Convert.ToInt32(productcode.Text)]);
                cm.Parameters.AddWithValue("@color", productcode.Text);
                cm.Parameters.AddWithValue("@no", no.Text);
                //string name=Session["username"].ToString();
                cm.Parameters.AddWithValue("@userid", Session["userid"]);

                bool flag = false;
                try
                {
                    co.Open();
                    cm.ExecuteNonQuery();
                    flag = true;
                    //Response.Cookies["danlopco"].Expires = DateTime.Now.AddDays(-1);
                }
                catch
                {

                }
                finally
                {
                    co.Close();
                    cm.Dispose();
                }
            }
        }
        protected void btnenter_Click(object sender, EventArgs e)
        {
            if (txtusername.Text.Trim() == "" || txtpassword.Text.Trim() == "")
            {
                lblmsg2.Text = "لطفا نام کاربری و رمز عبور خود را وارد نمایید ";
            }
            else
            {
                SqlConnection cnn = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
                SqlCommand cmd = new SqlCommand("select Id , UserName ,  Password from Tbl_UserSubmit where UserName='" + txtusername.Text + "' AND Password='" + txtpassword.Text + "'", cnn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr;
                try
                {
                    cnn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            Session["userid"] = dr["Id"].ToString();
                        }
                    //lblmsg.Text = "ok";
                    Response.Redirect("productpage.aspx");
                }
                catch
                {
                    lblmsg.Text = "متاسفانه خطایی رخ داده است";
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