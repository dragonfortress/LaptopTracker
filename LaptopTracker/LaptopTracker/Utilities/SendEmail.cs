using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

[assembly: CLSCompliant(true)]
namespace LaptopTracker.Utilities
{
    public class SendEmail
    {
        //static void Main(string[] args)
        //{

        //    //System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
        //    //message.To.Add("peterm@slalom.com");
        //    //message.Subject = "This is the Subject line";
        //    //message.From = new System.Net.Mail.MailAddress("test@algorithm.cs");
        //    //message.Body = "This is the message body";
        //    //System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
        //    //smtp.Send(message);

        //    SendMail("peterm@slalom.com", "pizzapete212@gmail.com");
        //}

        //public static void SendMail(String from, String to)
        //{
        //    SmtpClient client = new SmtpClient();
        //    client.Port = 587;
        //    client.Host = "smtp.gmail.com";
        //    client.EnableSsl = true;
        //    client.Timeout = 10000;
        //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = new System.Net.NetworkCredential(from, "0HT0NM5fGJq7bHpxM2mA");

        //    MailMessage mm = new MailMessage(
        //        from,
        //        to,
        //        "Test Message",
        //        "Time how long this takes to arrive.");
        //    mm.BodyEncoding = UTF8Encoding.UTF8;
        //    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

        //    client.Send(mm);
        //}

        //public static void SendMail()
        //{
        //    String to = "peterm@slalom.com";
        //    String from = "blueblazerbeam@gmail.com";

        //    SmtpClient client = new SmtpClient();
        //    client.Port = 587;
        //    client.Host = "smtp.gmail.com";
        //    client.EnableSsl = true;
        //    client.Timeout = 10000;
        //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = new System.Net.NetworkCredential(from, "0HT0NM5fGJq7bHpxM2mA");

        //    MailMessage mm = new MailMessage();

        //    MailMessage mm = new MailMessage(
        //        from,
        //        to,
        //        "Test Message",
        //        "I think it takes a while to get these from the time that they are sent.");
        //    mm.BodyEncoding = UTF8Encoding.UTF8;
        //    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

        //    MailAddress copy = new MailAddress("pizzapete212@gmail.com");

        //    client.Send(mm);
        //}

        public static void SendMail(string to, string cc)
        {
            String from = "blueblazerbeam@gmail.com"; //will be this until later
            using (SmtpClient client = new SmtpClient())
            {
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(from, "0HT0NM5fGJq7bHpxM2mA");

                string subject ="You have too many Laptops";
                string body = "Attention please. You have too many laptops. Please return one.";

                using (MailMessage mm = new MailMessage( from, to, subject, body ))
                {
                    mm.BodyEncoding = Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                    mm.CC.Add(cc);

                    client.Send(mm);  
                }
            }
        }
    }
}