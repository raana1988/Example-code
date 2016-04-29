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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    SqlConnection cnn = new SqlConnection(Vozaracoonnection.GetConnectionStringByName());
                    SqlCommand cmd = new SqlCommand("SELECT [Price], [OffPrice], [ProductName], [ImageUrl], [Id] FROM [Tbl_Product] where [Counter] > 0 AND ProductName like N'%"+Request.QueryString["content"].ToString()+"%'", cnn);
                    cnn.Open();
                    SqlDataAdapter drp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    drp.Fill(ds);
                    ImagesListView.DataSource = ds;
                    ImagesListView.DataBind();

                    cnn.Close();


                }
                catch (Exception ex)
                {
                    Label1.Text = "جستجوی شما نتیجه ای در بر نداشت";
                }

            }
        }
    }
}