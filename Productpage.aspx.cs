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
    public partial class Productpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if(!IsPostBack)
            {
                try
                {
                    SqlConnection cnn = new SqlConnection(Vozaracoonnection.GetConnectionStringByName());
                    SqlCommand cmd = new SqlCommand("SELECT [Price], [OffPrice], [ProductName], [ImageUrl], [Id] FROM [Tbl_Product] where [Counter] > 0", cnn);
                    cnn.Open();
                    SqlDataAdapter drp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    drp.Fill(ds);
                    ImagesListView.DataSource = ds;
                    ImagesListView.DataBind();
                   
                    cnn.Close();
                    
                    
                }
                catch(Exception ex)
                {

                }
               
            }

           
        }

        protected void chkfilterpro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string temp_query = "SELECT distinct (Tbl_Product.Id), [Price], [OffPrice], [ProductName], [ImageUrl] FROM [Tbl_Product] inner join Tbl_CarpetInFilter on Tbl_Product.Id=Tbl_CarpetInFilter.ProductId where Tbl_Product.[Counter]>0 ";
            bool counter =false;
            bool check_null = true;
            for (int i = 0; i < chkfilterpro.Items.Count; i++)
            {
                if (chkfilterpro.Items[i].Selected)
                {
                    check_null = false;
                    int idfilter = Convert.ToInt32(chkfilterpro.Items[i].Value);
                    if(!counter)
                    {
                        temp_query+=" AND Tbl_CarpetInFilter.FilterId = "+idfilter.ToString()+" ";
                        counter = true;
                    }
                    else
                    {
                        temp_query += " OR Tbl_CarpetInFilter.FilterId = " + idfilter.ToString() + " ";
                    }
                    try
                    {
                        
                    }
                    catch
                    {

                    }
                    finally
                    {

                    }
                }

            }
            if (check_null)
                temp_query = "SELECT [Price], [OffPrice], [ProductName], [ImageUrl], [Id] FROM [Tbl_Product] where [Counter] > 0";
            try
            {
                SqlConnection cnn = new SqlConnection(Vozaracoonnection.GetConnectionStringByName());
                SqlCommand cmd = new SqlCommand(temp_query, cnn);
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

            }
        }
    }
}