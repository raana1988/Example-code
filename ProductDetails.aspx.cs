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
    public partial class ProductDetails : System.Web.UI.Page
    {
        int temp = 0;
        int idcolor=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                temp = Convert.ToInt32(Request.QueryString["product"]);

                SqlConnection cnn = new SqlConnection(Vozaracoonnection.GetConnectionStringByName());
                SqlCommand cmd = new SqlCommand("Select_Pro", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", temp);
                try
                {
                    SqlDataReader dr;
                    cnn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            
                            ltrname.Text = @"<span style='color:green;font-size: 13px;'>"+dr["نام"].ToString()+"</span>";
                            ltrimg.Text = @"<img id='zoom_01' width='400px' src='../ProductImages/vlb_images1/" + dr["تصویر"].ToString() + "' data-zoom-image='../ProductImages/vlb_images1/" + dr["تصویر"].ToString() + "'/>";
                            ltrcolor.Text = @"<span style='color:green;font-size: 13px;'>" + dr["رنگ"].ToString() + "</span>";
                            lblcolor.Text = dr["کدرنگ"].ToString();
                            ltrcount.Text = @"<span style='color:green;font-size: 13px;'>" + dr["تعداد"].ToString() + "</span>";
                            ltrdesc.Text = @"<span style='color:green;font-size: 13px;'>" + dr["توضیحات"].ToString() + "</span>";
                            ltrdimen.Text = @"<span style='color:green;font-size: 13px;'>" + dr["ابعاد"].ToString() + "</span>";
                            string pic1=dr["عکس1"].ToString();
                            string pic2=dr["عکس2"].ToString();
                            string pic3=dr["عکس3"].ToString();
                            string pic4=dr["عکس4"].ToString();
                            if(pic1=="")
                            {
                                ltrpic1.Text = "";
                                    
                            }
                            else
                            {
                                ltrpic1.Text = @"<img class=thumnail' width='100px' src='../ProductImages/vlb_images1/" + dr["عکس1"].ToString() + "'/>";
                               
                            }
                            if(pic2=="")
                            {
                                ltrpic2.Text = "";
                            }
                            else
                            {
                                ltrpic2.Text = @"<img class=thumnail' width='100px' src='../ProductImages/vlb_images1/" + dr["عکس2"].ToString() + "'/>";
                            }
                            if(pic3=="")
                            {
                                ltrpic3.Text = "";
                            }
                            else
                            {
                                ltrpic3.Text = @"<img class=thumnail' width='100px' src='../ProductImages/vlb_images1/" + dr["عکس3"].ToString() + "'/>";
                            }
                            if(pic4=="")
                            {
                                ltrpic4.Text = "";
                            }
                            else
                            {
                                ltrpic4.Text = @"<img class=thumnail' width='100px' src='../ProductImages/vlb_images1/" + dr["عکس4"].ToString() + "'/>";
                            }
                            
                            
                            ltrproducer.Text =@"<span style='color:green'>"+dr["تولیدکننده"].ToString()+"</span>" ;
                            ltrshane.Text = @"<span style='color:green;font-size: 13px;'>" + dr["شانه"].ToString() + "</span>";
                            ltrtarakom.Text = @"<span style='color:green;font-size: 13px;'>" + dr["تراکم"].ToString() + "</span>";
                            ltrcode.Text = @"<span style='color:green;font-size: 13px;'>" + dr["کد"].ToString() + "</span>";
                            lblcode.Text = dr["کد"].ToString();
                            lblprice.Text = dr["تخفیف"].ToString();
                            ltrprice.Text = @"<span style='color:green;font-size: 18px;'>" + dr["قیمت"].ToString() + "</span>ريال";
                            ltrpriceoff.Text = @"<span style='color:red;font-size: 18px;'>" + dr["تخفیف"].ToString() + "</span>ريال";
                        }

                }
                catch(Exception ex)
                {
                    lblmsg.Text = ex.ToString();
                }
                finally
                {
                    cnn.Close();
                    cmd.Dispose();
                }
            }
            catch(Exception ex)
            {
                lblmsg.Text = ex.ToString();
            }
            finally
            {
              
            }

            SqlConnection cn = new SqlConnection(Vozaracoonnection.GetConnectionStringByName());
            SqlCommand cm = new SqlCommand("Select_CarpetColor",cn);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("productid",temp);
            SqlDataReader dd;
            try
            {
                cn.Open();
                dd = cm.ExecuteReader();
                if(dd.HasRows)
                    while(dd.Read())
                    {
                        ltrcolocarpet.Text += @"<img src='../ProductImages/vlb_images1/" + dd["تصویر"].ToString() + "' style='width:200px'/><br/>";
                    }
            }
            catch
            {
                
            }
            finally
            {
                cn.Close();
                cm.Dispose();
            }
        }
        protected void btnbuy_Click(object sender, EventArgs e)
        {
            //if (drpdimen.SelectedIndex == 0 || txtno.Text.Trim() == "")
            //{
            //    lblmsg.Text = "ابعاد و تعداد مورد نظر را انتخاب نمایید";
            //}
            //else
            //{

                try
                {
                    int userid = Convert.ToInt32(Session["userid"].ToString());
                    idcolor = Convert.ToInt32(RadioButtonList1.SelectedValue);
                    SqlConnection cn = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
                    SqlCommand cm = new SqlCommand("Insert_Basket", cn);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@no", 1);
                    cm.Parameters.AddWithValue("@color", idcolor);
                    cm.Parameters.AddWithValue("@proid", temp);
                    cm.Parameters.AddWithValue("@price", lblprice.Text);
                    cm.Parameters.AddWithValue("@userid", userid);
                    bool flag = true;
                    try
                    {
                        cn.Open();
                        cm.ExecuteNonQuery();
                        lblmsg.Text = "به سبد خرید اضافه شد";
                        flag = false;

                    } // second try
                    catch (Exception ex)
                    {
                        lblmsg.Text = "متاسفانه خطایی رخ داده است ";
                    }
                    finally
                    {
                        cn.Close();
                        cm.Dispose();
                        if (flag == false)
                        {
                            Response.Redirect("basket.aspx");
                        }
                    }

                } //first try
                catch (Exception ex)
                {
                    writecookies();
                }
            }


        protected void writecookies()
        {
            try
            {
                //Grab the cookie
                HttpCookie cookie = Request.Cookies["vozara"];

                //Check to make sure the cookie exists
                if (cookie == null)
                {
                    HttpCookie cookie2 = new HttpCookie("vozara");

                    //Set the cookies value
                    cookie2.Value = lblcode.Text + "-" + RadioButtonList1.SelectedValue + "-" + "1";

                    //Set the cookie to expire in 1 minute
                    //DateTime dtNow = DateTime.Now;
                    //TimeSpan tsMinute = new TimeSpan(0, 0, 1, 0);
                    //cookie.Expires = dtNow + tsMinute;
                    cookie2.Expires = DateTime.Now.AddDays(90);
                    //Add the cookie
                    Response.Cookies.Add(cookie2);
                }
                else if (cookie.Value.ToString().Trim() == string.Empty)
                {
                    HttpCookie cookie2 = new HttpCookie("vozara");

                    //Set the cookies value
                    cookie2.Value = lblcode.Text + "-" + RadioButtonList1.SelectedValue + "-" + "1";

                    //Set the cookie to expire in 1 minute
                    //DateTime dtNow = DateTime.Now;
                    //TimeSpan tsMinute = new TimeSpan(0, 0, 1, 0);
                    //cookie.Expires = dtNow + tsMinute;
                    cookie2.Expires = DateTime.Now.AddDays(90);
                    //Add the cookie
                    Response.Cookies.Add(cookie2);
                }
                else
                {
                    string str = cookie.Value.ToString();

                    cookie.Value = str + "_" + lblcode.Text + "-" + RadioButtonList1.SelectedValue + "-" + "1";

                    //Set the cookie to expire in 1 minute
                    //DateTime dtNow = DateTime.Now;
                    //TimeSpan tsMinute = new TimeSpan(0, 0, 1, 0);
                    //cookie.Expires = dtNow + tsMinute;
                    cookie.Expires = DateTime.Now.AddDays(90);
                    //Add the cookie
                    Response.Cookies.Add(cookie);
                    //Write the cookie value
                }
                lblmsg.Text = "به سبد خرید اضافه شد";

            }
            catch
            {
                HttpCookie cookie2 = new HttpCookie("vozara");
                //Set the cookies value
                cookie2.Value = lblcode.Text + "-" + RadioButtonList1.SelectedValue + "-" + "1";
                //Set the cookie to expire in 1 minute
                //DateTime dtNow = DateTime.Now;
                //TimeSpan tsMinute = new TimeSpan(0, 0, 1, 0);
                //cookie.Expires = dtNow + tsMinute;
                cookie2.Expires = DateTime.Now.AddDays(90);
                //Add the cookie
                Response.Cookies.Add(cookie2);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Basket.aspx");

        }

    }
}