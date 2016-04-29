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
    public partial class Basket : System.Web.UI.Page
    {
        string st = "";
        int indexrow;
        int indexrow1;
        Dictionary<int, string> dicminen = new Dictionary<int, string>();
        Dictionary<int, string> dicpro = new Dictionary<int, string>();
        Dictionary<int, string> dicprice = new Dictionary<int, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmsg.Visible = true;
            btnfactor.Visible = false;
            try
            {
                st = Session["userid"].ToString();

                lblmsg.Visible = false;
                btnfactor.Visible = true;

                SqlConnection cc = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
                SqlCommand cmo = new SqlCommand("select Id , NameFamily from Tbl_UserSubmit where Id=@st", cc);
                cmo.Parameters.AddWithValue("@st", st);
                cmo.CommandType = CommandType.Text;
                SqlDataReader dd;
                try
                {
                    cc.Open();
                    dd = cmo.ExecuteReader();
                    if (dd.HasRows)
                        while (dd.Read())
                        {
                            Session["username"] = dd["NameFamily"].ToString();
                        }
                }
                catch
                {

                }
                finally
                {
                    cc.Close();
                    cmo.Dispose();
                }
            }
            catch
            {
                //btnfactor.Visible = false;
                //btncookie.Visible = false; 
                prodimenname();
                if (!IsPostBack)
                {
                    ReadCookie();
                }
                if (!IsPostBack)
                    btncookie.Visible = true;
            }
        }
        protected void prodimenname()
        {

            SqlConnection cnn = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
            SqlCommand cmd = new SqlCommand("select Id, ColorName from Tbl_Color", cnn);
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
                        string dimension_name = dr["ColorName"].ToString();
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
            SqlCommand cmd1 = new SqlCommand("select Id, ProductName , OffPrice from Tbl_Product", cnn1);
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
                        string pro_offprice = dr1["OffPrice"].ToString();
                        dicpro.Add(idpro, pro_name);
                        dicprice.Add(idpro, pro_offprice);
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
           
        }

        protected void ReadCookie()
        {
            lblmsg.Visible = false;
            btncookie.Visible = true;
            DataTable dt = new DataTable();

            DataColumn cl2 = new DataColumn();
            cl2.ColumnName = "کد محصول";
            dt.Columns.Add(cl2);
            dt.Columns.Add("کد شناسايي");
            dt.Columns.Add("نام محصول");
            dt.Columns.Add("رنگ");

            DataColumn cl = new DataColumn();
            cl.ColumnName = "تعداد";
            dt.Columns.Add(cl);
            dt.Columns.Add("قیمت");
            dt.Columns.Add("قیمت کل");
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
                    try
                    {
                        string[] stunderline = strCookieValue.Split('_');
                        foreach (string stunderline_values in stunderline)
                        {
                            string[] stdash = stunderline_values.Split('-');
                            dt.Rows.Add(stdash[0], stdash[1], dicpro[Convert.ToInt32(stdash[0])], dicminen[Convert.ToInt32(stdash[1])], stdash[2], dicprice[Convert.ToInt32(stdash[0])], (Convert.ToInt32(dicprice[Convert.ToInt32(stdash[0])]) * (Convert.ToInt32(stdash[2]))).ToString());
                        }
                        GridView2.DataSource = dt;
                        GridView2.DataBind();
                        int t_price = 0;
                        foreach (GridViewRow r in GridView2.Rows)
                        {
                            t_price += Convert.ToInt32(((Label)r.Cells[7].FindControl("lbltprice")).Text);
                        }

                        lbltprice.Text = "قیمت نهایی : " + t_price.ToString() + "ریال";
                        //lblCookie.Text = strCookieValue + "</b><br><hr>";
                    }
                    catch
                    {
                        Response.Redirect("Homepage.aspx");
                    }
                }
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32((e.CommandArgument).ToString());
            //GridViewRow gvRow = GridView1.Rows[index];
            indexrow = index;
            if (hdf.Value == "0")
            {
                int i = indexrow;
                int id = Convert.ToInt32(((Label)GridView1.Rows[i].FindControl("lblId")).Text);

                string sqlconn = null;
                sqlconn = VozaraCarpet.Vozaracoonnection.GetConnectionStringByName();
                if (sqlconn != null)
                {
                    SqlConnection cn = new SqlConnection(sqlconn);
                    SqlCommand cmd = new SqlCommand("Update_buy", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    TextBox txtno = (TextBox)GridView1.Rows[i].Cells[5].FindControl("txtModifyNo");
                    cmd.Parameters.AddWithValue("@no", txtno.Text);
                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        GridView1.EditIndex = -1;
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        cn.Close();
                        cmd.Dispose();
                        hdf.Value = "-1";
                    }
                }
            }
            if (hdf.Value == "1")
            {
                int i = indexrow;
                int id = Convert.ToInt32(((Label)GridView1.Rows[i].FindControl("lblId")).Text);

                string sqlconn = null;
                sqlconn = VozaraCarpet.Vozaracoonnection.GetConnectionStringByName();
                if (sqlconn != null)
                {
                    SqlConnection cn = new SqlConnection(sqlconn);
                    SqlCommand cmd = new SqlCommand("DELETE  from Tbl_Buy  where Id=@id", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();

                        //lblmsg.Text = " اطلاعات با موفقیت حذف شد .";
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        //lblmsg.Text = "خطایی رخ داده است ، لطفا مجدد اقدام نمایید";

                    }
                    finally
                    {
                        cn.Close();
                        cmd.Dispose();
                    }
                    GridView1.DataBind();
                }


            }
            if (hdf.Value == "2")
            {
                hdf.Value = "0";
                GridView1.EditIndex = index;


            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            hdf.Value = "2";

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
            }
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            hdf.Value = "1";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("beforefactor.aspx");
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            hdf.Value = "3";
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            hdf.Value = "4";
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            /**********************************************************************************************************/
            /**********************************************************************************************************/
            /**********************************************************************************************************/
            /***************************************Delete*************************************************************/
            /**********************************************************************************************************/
            /**********************************************************************************************************/
            /**********************************************************************************************************/
            /**********************************************************************************************************/
            /**********************************************************************************************************/

            if (hdf.Value == "3")
            {
                int index1 = Convert.ToInt32(e.CommandArgument);
                //GridViewRow gvRow = GridView1.Rows[index];
                indexrow1 = index1;
                string mycoockie = "";
                DataTable dtt = new DataTable();
                dtt.Columns.Add("کد محصول ");//dimension id 
                dtt.Columns.Add("کد شناسايي");
                dtt.Columns.Add("نام محصول");
                dtt.Columns.Add("رنگ");

                dtt.Columns.Add("قیمت");
                dtt.Columns.Add("قیمت کل");
                int i = 0;
                foreach (GridViewRow rd in GridView2.Rows)
                {
                    Label lblno = (Label)rd.Cells[0].FindControl("lblNo");
                    if (rd.RowIndex != (indexrow1))
                    {
                        if (i == 0)
                        {
                            mycoockie += ((Label)rd.Cells[1].FindControl("lblNo2")).Text.Trim() + "-" + lblno.Text.Trim() + "-" + ((Label)rd.Cells[2].FindControl("lblNo4")).Text.Trim();
                            i++;
                        }
                        else
                        {
                            mycoockie += "_" + ((Label)rd.Cells[1].FindControl("lblNo2")).Text.Trim() + "-" + lblno.Text.Trim() + "-" + ((Label)rd.Cells[2].FindControl("lblNo4")).Text.Trim();
                        }
                        dtt.Rows.Add(lblno.Text.Trim() + "-" + ((Label)rd.Cells[1].FindControl("lblNo2")).Text.Trim() + "-" + ((Label)rd.Cells[2].FindControl("lblNo4")).Text.Trim() + "-" + ((Label)rd.Cells[3].FindControl("lblNo3")).Text.Trim() + "-" + ((Label)rd.Cells[4].FindControl("lbldimension")).Text.Trim() + "-" + lblno.Text.Trim() + "-" + ((Label)rd.Cells[6].FindControl("lblprice")).Text.Trim() + "-" + (Convert.ToInt32(((Label)rd.Cells[6].FindControl("lblprice")).Text) * (Convert.ToInt32(lblno.Text))).ToString());
                    }
                }
                //    Response.Cookies["danlopco"].Values = mycoockie;
                //first way
                HttpCookie cookie2 = new HttpCookie("vozara");
                cookie2.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(cookie2);
                HttpCookie cookie = Request.Cookies["vozara"];
                cookie.Expires = DateTime.Now.AddDays(90);
                cookie.Value = mycoockie;

                //Add the cookie
                Response.Cookies.Add(cookie);
                String strCookieValue = mycoockie;
                if (strCookieValue == string.Empty)
                {
                    btncookie.Visible = false;

                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
                else
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("کد محصول");//dimension id  
                        dt.Columns.Add("کد شناسايي");
                        dt.Columns.Add("نام محصول");
                        dt.Columns.Add("رنگ");

                        DataColumn cl = new DataColumn();
                        cl.ColumnName = "تعداد";
                        dt.Columns.Add(cl);
                        dt.Columns.Add("قیمت");
                        dt.Columns.Add("قیمت کل");

                        string[] stunderline = strCookieValue.Split('_');
                        foreach (string stunderline_values in stunderline)
                        {
                            string[] stdash = stunderline_values.Split('-');
                            dt.Rows.Add(stdash[0], stdash[2], dicpro[Convert.ToInt32(stdash[2])], dicminen[Convert.ToInt32(stdash[0])], stdash[1], dicprice[Convert.ToInt32(stdash[0])], (Convert.ToInt32(dicprice[Convert.ToInt32(stdash[0])]) * (Convert.ToInt32(stdash[1]))).ToString());

                        }
                        GridView2.DataSource = dt;
                        GridView2.DataBind();
                        if (dt.Rows.Count > 0)
                            lblmsg.Visible = false;
                        else
                            lblmsg.Visible = true;
                        hdf.Value = "-1";
                        //lblCookie.Text = strCookieValue + "</b><br><hr>";
                    }
                    catch
                    {
                        Response.Redirect("HomePage.aspx");
                    }
                    //Response.Cookies["danlopco"].Values["2:"] = String.Empty;
                }
            }
            /******************************************************************************************************************************************/
            /******************************************************************************************************************************************/
            /******************************************************************************************************************************************/
            /**************************UPDATE**********************************************************************************************************/
            /******************************************************************************************************************************************/
            /******************************************************************************************************************************************/
            /******************************************************************************************************************************************/
            /******************************************************************************************************************************************/
            /**/
            else if (hdf.Value.Trim() == "4")
            {
               
            }
        }
        protected void btncookie_Click(object sender, EventArgs e)
        {
            Response.Redirect("InformationBuyer.aspx");
        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {

            int editIndex = e.NewEditIndex;
            //hdf.Value = "4"; 

            GridView2.EditIndex = editIndex;
          
            ReadCookie();

           

        }
        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            ReadCookie();
        }
        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row2 = GridView2.Rows[e.RowIndex];

            string n = e.NewValues["تعداد"].ToString();
            //GridView2.Rows[0].Cells[5].Text = n.ToString();
            var newval = e.NewValues;
            int index1 = e.RowIndex;
            indexrow1 = index1;
            string mycoockie = "";
            int index = GridView2.EditIndex;
            GridViewRow row = GridView2.Rows[index];

            TextBox t1 = (TextBox)row.FindControl("nn") as TextBox;
            string number = "";
            try { number = t1.Text; }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
            DataTable dtt = new DataTable();
            dtt.Columns.Add("کد محصول");//dimension id 
            dtt.Columns.Add("کد شناسايي");
            dtt.Columns.Add("نام محصول");
            dtt.Columns.Add("رنگ");
            dtt.Columns.Add("قیمت");
            dtt.Columns.Add("قیمت کل");
            int i = 0;
            foreach (GridViewRow rd in GridView2.Rows)
            {

                if (rd.RowIndex == (indexrow1))
                {
                    TextBox lblno = (TextBox)GridView2.Rows[e.RowIndex].FindControl("nn");
                    if (i == 0)
                    {
                        mycoockie += ((Label)rd.Cells[1].FindControl("lblNo2")).Text.Trim() + "-" + ((Label)rd.Cells[2].FindControl("lblNo4")).Text.Trim() + "-" + lblno.Text.Trim();
                        i++;
                    }
                    else
                    {
                        mycoockie += "_" + ((Label)rd.Cells[1].FindControl("lblNo2")).Text.Trim() + "-" + ((Label)rd.Cells[2].FindControl("lblNo4")).Text.Trim() + "-" + lblno.Text.Trim();
                    }
                      dtt.Rows.Add(lblno.Text.Trim() + "-" + ((Label)rd.Cells[1].FindControl("lblNo2")).Text.Trim() + "-" + ((Label)rd.Cells[2].FindControl("lblNo4")).Text.Trim() + "-" + ((Label)rd.Cells[3].FindControl("lblNo3")).Text.Trim() + "-" + ((Label)rd.Cells[4].FindControl("lblcolor")).Text.Trim() + "-" + lblno.Text.Trim() + "-" + ((Label)rd.Cells[6].FindControl("lblprice")).Text.Trim());
                }
                else
                {

                    Label lblproduct_code = null;
                    Label txtshenasaie_no = null;
                    Label product_name = null;
                    Label dimention = null;
                    Label count_orig = null; ;
                    Label price = null;
                    try
                    {
                        //findcontrol
                        lblproduct_code = (Label)rd.Cells[1].FindControl("lblNo2");
                        txtshenasaie_no = (Label)rd.Cells[2].FindControl("lblNo4");
                        product_name = (Label)rd.Cells[3].FindControl("lblNo3");
                        dimention = (Label)rd.Cells[4].FindControl("lblcolor");
                        count_orig = (Label)rd.Cells[5].FindControl("lblNo");
                        price = (Label)rd.Cells[6].FindControl("lblprice");

                    }
                    catch (Exception ex)
                    {
                        string st = ex.Message;
                    }
                    if (i == 0)
                    {
                        mycoockie += lblproduct_code.Text.Trim() + "-" + txtshenasaie_no.Text.Trim() + "-" + count_orig.Text.Trim();
                        i++;
                    }
                    else
                    {
                        mycoockie += "_" + lblproduct_code.Text.Trim() + "-" + txtshenasaie_no.Text.Trim() + "-" + count_orig.Text.Trim();
                    }
                    dtt.Rows.Add(count_orig.Text.Trim() + "-" + txtshenasaie_no.Text.Trim() + "-" + txtshenasaie_no.Text.Trim() + "-" + product_name.Text.Trim() + "-" + dimention.Text.Trim() + "-" + lblHide.Text.Trim() + "-" + price.Text.Trim());

                }
            }
            //Response.Cookies["danlopco"].Values = mycoockie;
            //first way
            HttpCookie cookie3 = new HttpCookie("vozara");
            cookie3.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(cookie3);
            HttpCookie cookie1 = Request.Cookies["vozara"];
            cookie1.Expires = DateTime.Now.AddDays(90);
            cookie1.Value = mycoockie;

            //Add the cookie
            Response.Cookies.Add(cookie1);
            String strCookieValue1 = mycoockie;
            if (strCookieValue1 == string.Empty)
            {

                btncookie.Visible = false;
                //GridView2.DataSource = null;
                //GridView2.DataBind();
            }
            else
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("کد محصول");//dimension id  
                    dt.Columns.Add("کد شناسايي");
                    dt.Columns.Add("نام محصول");
                    dt.Columns.Add("رنگ");

                    DataColumn cl = new DataColumn();
                    cl.ColumnName = "تعداد";
                    dt.Columns.Add(cl);

                    dt.Columns.Add("قیمت");
                    dt.Columns.Add("قیمت کل");
                    string[] stunderline = strCookieValue1.Split('_');
                    int t_price = 0;
                    foreach (string stunderline_values in stunderline)
                    {
                        string[] stdash = stunderline_values.Split('-');
                        dt.Rows.Add(stdash[0], stdash[1], dicpro[Convert.ToInt32(stdash[0])], dicminen[Convert.ToInt32(stdash[1])], stdash[2], dicprice[Convert.ToInt32(stdash[0])], (Convert.ToInt32(dicprice[Convert.ToInt32(stdash[0])]) * Convert.ToInt32(stdash[2])).ToString());
                        t_price += Convert.ToInt32(dicprice[Convert.ToInt32(stdash[0])]) * Convert.ToInt32(stdash[2]);

                    }

                    GridView2.EditIndex = -1;
                    GridView2.DataSource = dt;

                    GridView2.DataBind();
                    if (dt.Rows.Count > 0)
                    {
                        lbltprice.Text = "قیمت نهایی : " + t_price.ToString() + "ریال";
                        lblmsg.Visible = false;
                    }
                    else
                    {
                        lblmsg.Visible = true;
                        lbltprice.Text = "";
                    }
                }
                catch
                {

                }

            }
        }

        protected void LinkButton3_Click1(object sender, EventArgs e)
        {
            hdf.Value = "0";
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            hdf.Value = "-1";
            GridView1.EditIndex = -1;
        }
    }
}