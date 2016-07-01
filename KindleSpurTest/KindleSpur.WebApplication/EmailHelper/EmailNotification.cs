using KindleSpur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace KindleSpur.WebApplication.MessageHelper
{
    public class EmailNotification
    {

        public static void SendEmail(User signupObject, string uri)
        {
            MailMessage message = new MailMessage("proxyserver.myur@gmail.com", signupObject.EmailAddress);
            message.Subject = "Account Activation";
            string body = "Hello " + signupObject.FirstName + ",";
            body += "<br/><br/>Please click the following link to activate your account<br/>";
            body += "<br/><br/><a style='background:#000000; color:#fafafa; padding:10px 100px 10px 100px; width:350px; text-decoration:none; font-weight:bold; font-size:20px;' href = '" + uri  + "'>Click here to activate your account.</a>";
            body += "<br /><br />Thanks, <br/> KindleSpur Team.";
            message.Body = body;
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("proxyserver.myur@gmail.com", "mayu3337sis");
            smtp.EnableSsl = true;
            smtp.Send(message);
        }

    }
}