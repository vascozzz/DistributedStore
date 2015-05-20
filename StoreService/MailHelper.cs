using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Diagnostics;

namespace StoreService
{
    static class MailHelper
    {
        private const string SMTPSERVER = "smtp.live.com";

        public static void SendMail(string clientAddress, string clientName, int orderId, string date)
        {
            // a new thread is created so we don't have to wait for email response
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                try
                {
                    SmtpClient mySmtpClient = new SmtpClient(SMTPSERVER);
                    mySmtpClient.Port = 587;
                    mySmtpClient.EnableSsl = true;

                    // set smtp-client with basicAuthentication
                    mySmtpClient.UseDefaultCredentials = false;
                    System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("tdinfeup1415@outlook.com", "OlaOla123");
                    mySmtpClient.Credentials = basicAuthenticationInfo;

                    // add from, to mailaddresses
                    MailAddress from = new MailAddress("tdinfeup1415@outlook.com", "Distributed Store");
                    MailAddress to = new MailAddress(clientAddress, clientName);
                    MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                    // set subject and encoding
                    myMail.Subject = "Distributed Store - Order successfully registered!";
                    myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                    // set body-message and encoding
                    myMail.Body = "Your new order has id " + orderId + ". <br>";
                    myMail.Body += "It is expected to arrive on " + date + ". Please consult our website for more details.";
                    myMail.BodyEncoding = System.Text.Encoding.UTF8;
                    myMail.IsBodyHtml = true;

                    Debug.WriteLine("Sending email...");
                    mySmtpClient.Send(myMail);
                    Debug.WriteLine("Email successfully sent!");
                }

                catch (SmtpException ex)
                {
                    throw new ApplicationException("SmtpException has occured: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }).Start();
        }
    }
}
