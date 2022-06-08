using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace VirtualTrading.Common
{
    public static class VTCommonEmail
    {
        
        public static void SendEmail(String subject, string body, string UserEmailAdd, string From, string userName, String Password, String SMPTServer) 
        {
            MailMessage msg = new MailMessage(From, UserEmailAdd, subject, body);

            try
            {
                SmtpClient smtpClient = new SmtpClient(SMPTServer)
                {
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(userName, Password),
                    Port = 587,
                    EnableSsl = true,
                };
                smtpClient.Send(msg);
                msg.Dispose();
                smtpClient.Dispose();
                //return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                //return false;
            }


        }
       
    }
}
