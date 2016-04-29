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
    public partial class Submit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtaddress.Text.Trim() == "" || txtmail.Text.Trim() == "" || txtmob.Text.Trim() == "" || txtname.Text.Trim() == "" || txtpass.Text.Trim() == "" || txtuser.Text.Trim() == "" || txtpostcode.Text.Trim() == "" || txtrepeat.Text.Trim() == "")
            {
                lblmsg.Text = "لطفا اطلاعات خواسته شده را کامل نمایید.";

            }
            else if (txtpass.Text != txtrepeat.Text)
            {
                lblmsg.Text = "تکرار رمز عبور اشتباه است";
            }

            else
            {
                SqlConnection cnn = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
                SqlCommand cmd = new SqlCommand("Insert_UserSubmit", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@username", txtuser.Text);
                cmd.Parameters.AddWithValue("@password", txtpass.Text);
                cmd.Parameters.AddWithValue("@email", txtmail.Text);
                cmd.Parameters.AddWithValue("@mobile", txtmob.Text);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@postcode", txtpostcode.Text);
                
                SqlDataReader dr;
                bool flag = false;
                try
                {
                    cnn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            Session["userid"] = dr["Id"].ToString();
                        }

                    lblmsg.Text = "کاربر با موفقیت در سیستم ثبت شد";
                    flag = true;


                }
                catch (Exception ex)
                {
                    lblmsg.Text = "متاسفانه خطایی رخ داده است ";
                }
                finally
                {
                    cnn.Close();
                    cmd.Dispose();
                    if (flag == true)
                    {
                        Response.Redirect("../pages/EnterUser.aspx");
                    }
                }
            }
        }
    }
}