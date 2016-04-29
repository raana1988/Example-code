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
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /***************************************Top menu****************************/

            SqlConnection cntop = new SqlConnection(Vozaracoonnection.GetConnectionStringByName());
            SqlCommand cmdtop = new SqlCommand("SELECT Tbl_TopMenu.Id AS TopMenu, Tbl_Filter.Name AS نام, Tbl_TopMenu.filterId AS sfilterid FROM Tbl_TopMenu INNER JOIN Tbl_Filter ON Tbl_TopMenu.filterId = Tbl_Filter.Id ", cntop);
            cmdtop.CommandType = CommandType.Text;
            SqlDataReader drtop;
            try
            {
                cntop.Open();
                drtop = cmdtop.ExecuteReader();
                if(drtop.HasRows)
                    while(drtop.Read())
                    {
                        ltrtopmenu.Text += @"<li class='nv'><a href='#'>"+drtop["نام"].ToString()+"</a></li>";
                    }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                cntop.Close();
                cmdtop.Dispose();
            }
            /**************************************Left menu***************************************/
            SqlConnection cnleft = new SqlConnection(Vozaracoonnection.GetConnectionStringByName());
            SqlCommand cmdleft = new SqlCommand("select Tbl_Filter.Id , Tbl_Filter.Name As نام from Tbl_Filter where Tbl_Filter.Id not in (select Tbl_TopMenu.FilterId from Tbl_TopMenu)",cnleft);
            cmdleft.CommandType = CommandType.Text;
            SqlDataReader drleft;
            try
            {
                cnleft.Open();
                drleft = cmdleft.ExecuteReader();
                if(drleft.HasRows)
                    while(drleft.Read())
                    {
                        ltrletfmenu.Text += @"<li><a href='#'>"+drleft["نام"].ToString()+"</a></li>";
                    }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                cnleft.Close();
                cmdleft.Dispose();
            }
            /*******************************************productslider**************************************/
            List<int> listfilterid = new List<int>();
            
            SqlConnection cnn = new SqlConnection(Vozaracoonnection.GetConnectionStringByName());
            SqlCommand cmd = new SqlCommand("SELECT Tbl_Slider.Id AS SliderId, Tbl_Filter.Name AS نام, Tbl_Slider.filterId AS sfilterid FROM Tbl_Slider INNER JOIN Tbl_Filter ON Tbl_Slider.filterId = Tbl_Filter.Id ", cnn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr;
            try
            {
                cnn.Open();
                dr = cmd.ExecuteReader();
                int counter = 1;
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        listfilterid.Add(Convert.ToInt32(dr["sfilterid"]));
                        
                        switch (counter)
                        {
                            case 1:
                                {
                                    lbl1.Text = dr["نام"].ToString();
                                    counter++;
                                    break;
                                }
                            case 2:
                                {
                                    lbl2.Text = dr["نام"].ToString();
                                    counter++;
                                    break;
                                }
                            case 3:
                                {
                                    lbl3.Text = dr["نام"].ToString();
                                    counter++;
                                    break;
                                }
                            default: break;
                        }

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

                SqlConnection con = new SqlConnection(Vozaracoonnection.GetConnectionStringByName());
                SqlCommand cm = new SqlCommand("select ProductName,Price,OffPrice,ImageUrl,Tbl_Product.Id as Id from Tbl_Product inner join Tbl_CarpetInFilter on Tbl_Product.Id=Tbl_CarpetInFilter.ProductId where FilterId='" + listfilterid[0] + "'", con);
                cm.CommandType = CommandType.Text;
                SqlDataReader sdr;
                try
                {
                    con.Open();
                    sdr = cm.ExecuteReader();
                    if(sdr.HasRows)
                        while (sdr.Read())
                        {
                            string s = sdr["ImageUrl"].ToString();
                            string m = sdr["ProductName"].ToString();
                            string n = sdr["Price"].ToString();
                            string a = sdr["OffPrice"].ToString();
                            ltrslider1.Text += @"<a href='../Pages/ProductDetails.aspx?product=" + sdr["Id"].ToString() + "'><div class='slide'><img src='../ProductImages/vlb_images1/" + sdr["ImageUrl"].ToString() + "' class='x'/><br /><span style=\"font-family:'B Yekan'; font-size:15px;\">" + sdr["ProductName"].ToString() + "</span><br /><span style=\"font-family:'B Yekan'; color:red;\"><del>" + sdr["Price"].ToString() + " ریال</del></span><br /><span style=\"font-family: 'B Yekan'; color: #2b9000;\">" + sdr["OffPrice"].ToString() + " ريال</span></div></a>";
                        }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                    cm.Dispose();

                }

                SqlConnection con1 = new SqlConnection(Vozaracoonnection.GetConnectionStringByName());
                SqlCommand cmd1 = new SqlCommand("select ProductName,Price,OffPrice,ImageUrl,Tbl_Product.Id as Id from Tbl_Product inner join Tbl_CarpetInFilter on Tbl_Product.Id=Tbl_CarpetInFilter.ProductId where FilterId='" + listfilterid[1] + "'", con1);
                cmd1.CommandType = CommandType.Text;
                SqlDataReader sdr1;
                try
                {
                    con1.Open();
                    sdr1 = cmd1.ExecuteReader();
                    if (sdr1.HasRows)
                        while (sdr1.Read())
                        {
                            ltrslider2.Text += @"<a href='../Pages/ProductDetails.aspx?product=" + sdr1["Id"].ToString() + "'><div class='slide'><img src='../ProductImages/vlb_images1/" + sdr1["ImageUrl"].ToString() + "' class='x'/><br /><span style=\"font-family:'B Yekan'; font-size:15px;\">" + sdr1["ProductName"].ToString() + "</span><br /><span style=\"font-family:'B Yekan'; color:red;\"><del>" + sdr1["Price"].ToString() + " ریال</del></span><br /><span style=\"font-family: 'B Yekan'; color: #2b9000;\">" + sdr1["OffPrice"].ToString() + " ريال</span></div></a>";
                        }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con1.Close();
                    cmd1.Dispose();
                }

                SqlConnection con2 = new SqlConnection(Vozaracoonnection.GetConnectionStringByName());
                SqlCommand cmd2 = new SqlCommand("select ProductName,Price,OffPrice,ImageUrl,Tbl_Product.Id as Id from Tbl_Product inner join Tbl_CarpetInFilter on Tbl_Product.Id=Tbl_CarpetInFilter.ProductId where FilterId=" + listfilterid[2] + "", con2);
                cmd2.CommandType = CommandType.Text;
                SqlDataReader sdr2;
                try
                {
                    con2.Open();
                    sdr2 = cmd2.ExecuteReader();
                    if (sdr2.HasRows)
                        while (sdr2.Read())
                        {
                            ltrslider3.Text += @"<a href='../Pages/ProductDetails.aspx?product="+sdr2["Id"].ToString()+"'><div class='slide'><img src='../ProductImages/vlb_images1/" + sdr2["ImageUrl"].ToString() + "' class='x'/><br /><span style=\"font-family:'B Yekan'; font-size:15px;\">" + sdr2["ProductName"].ToString() + "</span><br /><span style=\"font-family:'B Yekan'; color:red;\"><del>" + sdr2["Price"].ToString() + " ریال</del></span><br /><span style=\"font-family: 'B Yekan'; color: #2b9000;\">" + sdr2["OffPrice"].ToString() + " ريال</span></div></a>";
                        }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con2.Close();
                    cmd2.Dispose();
                }
            
            }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/Search.aspx?content="+txtsr.Text);
        }
        
    }
}