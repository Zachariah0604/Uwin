using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Resources;
using System.IO;

namespace BLL
{
    public class SMTPManager
    {
        public SMTPManager()
        {
        }
        public static void SendEmail(string FROM, string FromDisplayName, string TO, string BODY, string SUBJECT, bool bIsHtml)
        {
            MailMessage m = new MailMessage();
            m.From = new MailAddress(FROM, FromDisplayName);
            m.To.Add(TO);
            m.Subject = SUBJECT;
            m.Body = BODY;
            m.BodyEncoding = System.Text.Encoding.UTF8;
            m.IsBodyHtml = bIsHtml;
            m.ReplyTo = new MailAddress(FROM);
            SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 25);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("zachariah0604@live.com", "-xiaoluolin06045");
            

            smtp.Send(m);

        }
    }
}
