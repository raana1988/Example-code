using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;

namespace PRojectCH
{
    public partial class rmpFarsi : System.Web.UI.Page
    {
        public int counter = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string geturl(int temp_id)
    {
        return "product_detail.aspx?product=" + temp_id.ToString();
    }
    protected void ImageListView_ItemDataBound(
        object sender, ListViewItemEventArgs e)
    {
        
        ListViewDataItem dataItem = (ListViewDataItem)e.Item;

        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            HtmlTableCell Td1 = (HtmlTableCell)e.Item.FindControl("Td1");
            DataRowView rowView = (DataRowView)dataItem.DataItem;
            string temp_color = "";
            switch (counter)
            {
                case 3:
                    {
                        temp_color = "#fd6706";
                    }break;
                case 2:
                    {
                        temp_color = "#002062";
                    }break;
                case 1:
                    {
                        temp_color = "#8E989D";
                    }
                    break;
                case 0:
                    {
                        temp_color = "#667177";
                    }break;
                default: { temp_color = "#502460"; } break;
            }
            counter++;
            if (counter > 4)
                counter = 0;
            Td1.Style.Add("background-color",temp_color);
        }

    }

}
    }
