using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;

namespace PRojectCH
{
    public partial class AlbumFarsi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string createThumbString(string AlbumName, string Date)
        {
            
          //  return AlbumName + "" + calender(Convert.ToDateTime(Date));
            string str2 = "";
            str2 = "<table cellspacing='0' cellpadding='0' style='margin-bottom:20px;border:none;text-align:center; width: 280px;margin-left:40px;font-family:b yekan'><tr><td style='width:200px; /*direction:rtl; overflow:hidden;*/ position:relative;text-align:center;color:rgb(48, 47, 47);font-family:b yeka'>" + AlbumName + "</td><td style='width:10px'/><td style='width:50px; direction:ltr; /*overflow:hidden; */ position:relative; float=left; margin-top: -19px;color:rgb(48, 47, 47);font-family:b yeka'>" + calender(Convert.ToDateTime(Date)) + "</td></tr></table>";
            return str2;
        }

        protected string calender(DateTime Date)
        {
            //DateTime date
            PersianCalendar pc = new PersianCalendar();
            DateTime date = Date;

            // Display the current date using the Gregorian and Persian calendars. 

            return pc.GetYear(Date) + "/" + pc.GetMonth(Date).ToString("00") + "/" + pc.GetDayOfMonth(Date).ToString("00");
        }

        public string ERR { get; set; }

        public object AlbumUrl { get; set; }

        public object AlbumName { get; set; }

        public object DateAlbum { get; set; }

        public object AlbumDescription { get; set; }
    }
}