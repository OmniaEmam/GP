using System;
using System.Linq;
using System.Text;
using System.Web;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace NewGP.Controllers
{
    public static class Utils
    {
        //utils
        static public bool sendMail(string receiverEmail, string receiverName, string token, string username)
        {
            try
            {
                //admin email
                string sender = "basmamagdytest@gmail.com";
                string pss = "RmFrZS4xMjM0NTY3ODk=";
                string pw = Encoding.UTF8.GetString(Convert.FromBase64String(pss));
                string body = "here is your activation link: <a href='https://localhost:44306/Account/Activate?uname=" + username + "&token=" + token + "'>Click Here To Activate Your Account!</a>";
                string subject = "Activate your account At Reunion";

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(sender));
                email.To.Add(MailboxAddress.Parse(receiverEmail));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = body };

                // send email
                var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                smtp.Authenticate(sender, pw);
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        static public string GetUrlParameter(HttpRequestBase request, string parName)
        {
            string result = string.Empty;

            var urlParameters = HttpUtility.ParseQueryString(request.Url.Query);
            if (urlParameters.AllKeys.Contains(parName))
            {
                result = urlParameters.Get(parName);
            }
            return result;
        }
        static public string genToken(int l)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var token = new string(Enumerable.Repeat(chars, l).Select(s => s[random.Next(s.Length)]).ToArray());
            return token;
        }
        static public bool sendMailingMsg(string receiverEmail, string receiverName, string subj, string message)
        {
            try
            {
                //admin email
                string sender = "basmamagdytest@gmail.com";
                string pss = "RmFrZS4xMjM0NTY3ODk=";
                string pw = Encoding.UTF8.GetString(Convert.FromBase64String(pss));
                string body = message;

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(sender));
                email.To.Add(MailboxAddress.Parse(receiverEmail));
                email.Subject = subj;
                email.Body = new TextPart(TextFormat.Html) { Text = body };

                // send email
                var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                smtp.Authenticate(sender, pw);
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
        }
        static public bool sendAdminMail(string receiverEmail, string receiverName, string subj, string message)
        {
            try
            {
                //admin email
                string sender = "reunionadm.2@gmail.com";
                string pss = "VGVzdC4xMjM=";
                string pw = Encoding.UTF8.GetString(Convert.FromBase64String(pss));
                string body = message;

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(sender));
                email.To.Add(MailboxAddress.Parse(receiverEmail));
                email.Subject = subj;
                email.Body = new TextPart(TextFormat.Html) { Text = body };

                // send email
                var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                smtp.Authenticate(sender, pw);
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
        }
    }
}