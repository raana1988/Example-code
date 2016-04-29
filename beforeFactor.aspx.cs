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
    public partial class beforeFactor : System.Web.UI.Page
    {
        string st;
        string buyername;
        Dictionary<int, string> dicminen = new Dictionary<int, string>();
        Dictionary<int, string> dicpro = new Dictionary<int, string>();
        Dictionary<int, string> dicprice = new Dictionary<int, string>();

        protected void Page_PreRender(object sender, EventArgs e)
        {
            try
            {

                st = Session["userid"].ToString();
                Button1.Visible = true;
                SqlConnection cc = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
                SqlCommand cmo = new SqlCommand("select Id , NameFamily from Tbl_UserSubmit where Id=" + st, cc);
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
                            ltrusername.Text = Session["username"].ToString();

                        }
                }
                catch
                {

                }


            }
            catch
            {
                try
                {


                    Button2.Visible = true;
                    buyername = Session["user"].ToString();
                    SqlConnection cc = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
                    SqlCommand cmo = new SqlCommand("select Id , NameFamily from Tbl_Buyer where Id=" + buyername, cc);
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
                                ltrusername.Text = Session["username"].ToString();
                            }
                    }
                    catch
                    {

                    }
                    prodimenname();
                    ReadCookie();
                }
                catch
                {
                    Response.Redirect("ProductGroup.aspx");
                }
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

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
            SqlCommand cmd1 = new SqlCommand("select Id, ProductName,OffPrice from Tbl_Product", cnn1);
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
                        dicprice.Add(idpro, dr1["OffPrice"].ToString());
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
            SqlCommand cmd2 = new SqlCommand("select Id, ColorName from Tbl_Color", cnn2);
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
                        string price_name = dr2["ColorName"].ToString();
                        //  dicprice.Add(idp, price_name);
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
                    int totalprice = 0;
                    foreach (string stunderline_values in stunderline)
                    {
                        string[] stdash = stunderline_values.Split('-');
                        totalprice += Convert.ToInt32(stdash[2]) * Convert.ToInt32(dicprice[Convert.ToInt32(stdash[0])]);
                        dt.Rows.Add(stdash[0], dicpro[Convert.ToInt32(stdash[0])], dicminen[Convert.ToInt32(stdash[1])], stdash[2], dicprice[Convert.ToInt32(stdash[0])]);

                    }

                    GridView2.DataSource = dt;
                    GridView2.DataBind();

                    ltrprice.Text = totalprice.ToString() + "ریال";
                    //lblCookie.Text = strCookieValue + "</b><br><hr>";
                }
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string price = e.Row.Cells[0].Text; //Gets the value in Column 1
                string no = ((Label)e.Row.Cells[5].FindControl("lblNo")).Text; //Gets the value in Column 2
                Label lblprice = (Label)e.Row.Cells[7].FindControl("lblPriceId");  //
                Label lblTotal = (Label)e.Row.Cells[7].FindControl("lblprice");
                price = lblprice.Text;
                if (price == string.Empty || price == "")
                { price = "0"; }
                if (no == string.Empty || no == "")
                { no = "0"; }
                int sum = int.Parse(price) * int.Parse(no);
                lblTotal.Text += sum.ToString();
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Basket.aspx");
        }
        protected void GridView1_Load(object sender, EventArgs e)
        {
            //   ltrprice.Text = "";
            if (Session["userid"] != null)
            {
                ltrprice.Text = "";
                int sum = 0;
                foreach (GridViewRow rd in GridView1.Rows)
                {

                    Label lblTotal = (Label)rd.Cells[7].FindControl("lblprice");
                    string price = lblTotal.Text;
                    if (price == string.Empty || price == "")
                    { price = "0"; }

                    sum += int.Parse(price);


                }

                ltrprice.Text = sum.ToString() + " ریال";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkAll())
            {
                foreach (GridViewRow row1 in GridView1.Rows)
                {
                    Label price = row1.FindControl("lblPriceId") as Label;
                    Label product = row1.FindControl("lblProductId") as Label;
                    Label dimension = row1.FindControl("lblDimensionId") as Label;
                    Label no = row1.FindControl("lblNo") as Label;
                    SqlConnection co = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
                    SqlCommand cm = new SqlCommand("insert into Tbl_Factor(price, product, dimension,No,userid) values(@price, @product,@dimension,@no,@userid) ", co);
                    cm.CommandType = CommandType.Text;
                    cm.Parameters.AddWithValue("@price", price.Text);
                    cm.Parameters.AddWithValue("@product", product.Text);
                    cm.Parameters.AddWithValue("@dimension", dimension.Text);
                    cm.Parameters.AddWithValue("@no", no.Text);
                    //string name=Session["username"].ToString();
                    cm.Parameters.AddWithValue("@userid", st);
                    bool flag = false;
                    try
                    {
                        co.Open();
                        cm.ExecuteNonQuery();
                        flag = true;
                        ////////////////////////////////delete table_buy
                        SqlConnection conn = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
                        SqlCommand cmd = new SqlCommand("delete from Tbl_Buy where UserId" + st, conn);
                        cmd.CommandType = CommandType.Text;
                        try
                        {
                            conn.Open();
                            cmd.ExecuteReader();
                        }
                        catch
                        {

                        }
                        finally
                        {
                            conn.Close();
                            cmd.Dispose();
                        }
                    }/////////////end delete
                    catch
                    {

                    }
                    finally
                    {
                        co.Close();
                        cm.Dispose();
                        //if (flag = true)
                        //{
                        //    Response.Redirect("beforefactor.aspx");
                        //}
                    }
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkAll())
            {
                foreach (GridViewRow row2 in GridView2.Rows)
                {
                    Label price = row2.FindControl("lblPriceId") as Label;
                    Label product = row2.FindControl("lblProduct") as Label;
                    Label productcode = row2.FindControl("lblProductid") as Label;
                    Label dimension = row2.FindControl("lblDimension") as Label;
                    Label no = row2.FindControl("lblNo") as Label;
                    SqlConnection co = new SqlConnection(VozaraCarpet.Vozaracoonnection.GetConnectionStringByName());
                    SqlCommand cm = new SqlCommand("insert into Tbl_Buyerfactor(Price, ProductName, Dimension,No,Buyer,ProductCode) values(@price, @product,@dimension,@no,@userid,@productcode) ", co);
                    cm.CommandType = CommandType.Text;
                    cm.Parameters.AddWithValue("@price", price.Text);
                    cm.Parameters.AddWithValue("@product", product.Text);
                    cm.Parameters.AddWithValue("@productcode", productcode.Text);
                    cm.Parameters.AddWithValue("@dimension", dimension.Text);
                    cm.Parameters.AddWithValue("@no", no.Text);
                    cm.Parameters.AddWithValue("@userid", buyername);

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
        }
        public string getcardinfo(string cardname, string info)
        {

            return cardname + "-" + info;

        }
        private bool checkAll()
        {
            bool checkrdl = false;
            bool checkAddress = true;
            int j = 0;
            foreach (GridViewRow rd in grdTransfer.Rows)
            {
                bool temp_checkrdl = ((RadioButton)rd.FindControl("rdlTransfer")).Checked;
                if (temp_checkrdl)
                {
                    checkrdl = true;
                    break;


                }
            }
            if (checkrdl)
            {
                if (txtAddress.Text.Length < 20 || txtAddress.Text == "" || txtAddress.Text == null)
                {
                    checkAddress = false;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "آدرس را بصورت کامل وارد نمایید";
                    return false;
                }
                /*-------------------------------چک کد پستی 10 رقمی------------------*/

                else if (Int32.TryParse(TxtPostalCode.Text, out j))
                {



                }
                if ((j == 0 && TxtPostalCode.Text.Trim() != "") || (TxtPostalCode.Text.Trim().Length > 0 && TxtPostalCode.Text.Trim().Length != 10))
                {
                    checkAddress = false;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = " کدپستی را بصورت 0000000000 که 10 رقم متوالی است وارد نمایید نوشتن کد پستی الزامی نیست ولی بهتر است وارد فرمایید.";
                    return false;

                }
                /*-----------------------------*/
                if (txtDest.Text == "" || txtDest.Text == null)
                {
                    checkAddress = false;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "نام تحویل گیرنده الزامی است .درهنگام تحویل کارت ملی شخص مذکور رویت می گردد ";
                    return false;

                }

            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "روش ارسال مرسوله را انتخاب ننوده اید";
                return false;
            }
            if (checkAddress)
                return true;
            return false;

        }

        protected void rdlTransfer_CheckedChanged(object sender, EventArgs e)
        {
            string ff = e.ToString();
        }

        protected void grdTransfer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
        }
    }
}