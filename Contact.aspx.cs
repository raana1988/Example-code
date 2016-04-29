using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace VozaraCarpet.Pages
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack)
            {
                initialaze();
            }
        }
        private void initialaze()
        {


        }
        protected void btnsend_Click(object sender, EventArgs e)
        {
            SendEmail();
        }
        void SendEmail()
        {

            try
            {
                SmtpClient smptclient = new SmtpClient();
                MailMessage MailMsg = new MailMessage(new MailAddress("balutwebpr@gmail.com"), new MailAddress("balutwebpr@gmail.com"));
                smptclient.Host = "smtp.gmail.com";
                MailMsg.IsBodyHtml = true;
                MailMsg.SubjectEncoding = Encoding.UTF8;
                MailMsg.Subject = "تماس با ما";
                NetworkCredential userI = new NetworkCredential();
                userI.UserName = "balutwebpr@gmail.com";
                userI.Password = "NaaaM2@@2";
                smptclient.UseDefaultCredentials = true;
                smptclient.Credentials = userI;
                smptclient.EnableSsl = true;
                smptclient.Port = 587;
                string body = "<div style='width:960px; margin-top:20px; margin-bottom:auto; margin-left:auto; margin-right:auto; height:320px '>" +
                "<table style='direction:rtl;width:700px;background-color:pink;font-family:Tahoma;'><tr><td style='font-family:Tahoma'>نام و نام خانوادگی :</td><td><p style='font-family:Tahoma'>  " + Server.HtmlEncode(txtname.Text.Trim()) + " </p></td></tr>" +
               "<tr style='height:30px'></tr><tr><td style='font-family:Tahoma'>شماره تماس :</td><td> <p style='font-family:Tahoma'>" + Server.HtmlEncode(txttell.Text) + "</p></td></tr>" +
               "<tr style='height:30px'></tr><tr><td style='font-family:Tahoma'>ایمیل :</td><td> <p style='font-family:Tahoma'>" + Server.HtmlEncode(txtmail.Text) + "</p></td></tr>" +
                "<tr style='height:30px'></tr><tr><td style='font-family:Tahoma'>پیام :</td><td> <p style='font-family:Tahoma'>" + Server.HtmlEncode(txtrequest.Text.Trim()) + "</p></td></tr><tr style='height:10px'></tr><tr><td></td></tr>" +
               "</table></div>";
                MailMsg.Body = body;
                smptclient.Send(MailMsg);
                lblmsg.ForeColor = System.Drawing.Color.Green;
                lblmsg.Text = " پيام شما با موفقيت ارسال شد ، در اولین فرصت به آن پاسخ داده خواهد شد . ";

            }
            catch
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = " متاسفانه پیام شما ارسال نشد . لطفا دوباره تلاش فرمایید یا با شماره تلفن های دفترمرکزی تماس بگیرید. ";
                return;
            }
        }
    }
}