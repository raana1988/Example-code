using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRojectCH
{
    public partial class contactusFarsi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public bool TestEmailRegex(string emailAddress)
        {

            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
                  + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                  + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                  + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                  + @"[a-zA-Z]{2,}))$";
            Regex reStrict = new Regex(patternStrict);
            bool isStrictMatch = reStrict.IsMatch(emailAddress);
            return isStrictMatch;

        }



        protected void btnclick_Click(object sender, EventArgs e)
        {

            if (TestEmailRegex(mail.Text.ToString()))
            {

                if ((mail.Text.Trim() != "") & (name.Text.Trim() != "") & (payam.Text.Trim() != ""))
                {

                    SendEmail();
                    name.Text = "";
                    mail.Text = "";
                    payam.Text = "";


                }

            }
            else
            {
                alert.Text = "ایمیل نا معتبر است ";
            }
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
                userI.Password = "balutwebpr@";
                smptclient.UseDefaultCredentials = false;
                smptclient.Credentials = userI;
                smptclient.EnableSsl = true;
                //  smptclient.Port = 587;
                string body = "<div style='width:960px; margin-top:20px; margin-bottom:auto; margin-left:auto; margin-right:auto; height:320px '>" +
                "<table><tr><td><input type='text' id='name'/>" + Server.HtmlEncode(name.Text.Trim()) + "</td><td><p style='font-weight:bold;font-family:'B Yekan';font-size:larger;color:#666;text-shadow:2px 2px 2px #fff'>  نام و نام خانوادگی : </p></td></tr>" +
                "<tr style='height:10px'></tr><tr><td><input type='text' id='email'/>" + Server.HtmlEncode(mail.Text.Trim()) + "</td><td> <p style='font-weight:bold; font-family:'B Yekan'; font-size:larger;color:#666; text-shadow:2px 2px 2px #fff'> آدرس Email :</p></td></tr>" +
                "<tr style='height:10px'></tr><tr><td><textarea id='comment' style='width:300px; height:100px; resize:none'></textarea>" + Server.HtmlEncode(payam.Text.Trim()) + "</td><td> <p style='font-weight:bold; font-family:'B Yekan'; font-size:larger;color:#666; text-shadow:2px 2px 2px #fff'>پیام :</p></td></tr><tr style='height:10px'></tr><tr><td><input type='button' value='&nbsp;&nbsp;ثبت&nbsp;&nbsp;' id='btn' /></td></tr></table></div>";
                MailMsg.Body = body;
                smptclient.Send(MailMsg);
                this.Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "<script language=JavaScript>alert(' پيام شما با موفقيت فرستاده شد ');</script>");

            }
            catch
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "<script language=JavaScript>alert(' خطا در ارسال ايميل ');</script>");
                return;
            }
        }
    }
}