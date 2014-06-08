using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;


namespace afdsl.BusinessLayer.afdsl.Helper
{
    public class afdsl_MailFunctions
    {
        public string afdsl_FilePath { get; set; }
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public void SendMail(string from, string to, string subject, string body)
        {
            MailMessage msg = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("auth.smtp.1and1.co.uk");
            try
            {
                msg.From = new MailAddress(from);
                msg.To.Add(to);
                msg.Subject = subject;
                msg.IsBodyHtml = true;
                msg.Body = body;
                smtpClient.Port = 25;
                smtpClient.Credentials = new NetworkCredential("contact@afdsl.net", "D1g1tAL");
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);
            }
            catch (Exception es)
            {
                throw es;
            }
            finally
            {
                msg = null;
                smtpClient = null;
            }
        }
        
        public string populateResistrationEmailTemplate(string afdsl_FilePath, string UserName, string BaseUrl, string GUID)
        {
            StreamReader sr = new StreamReader(afdsl_FilePath);
            try
            {
                string emailfile = sr.ReadToEnd();
                emailfile = emailfile.Replace("$$$UserName$$$", UserName);
                emailfile = emailfile.Replace("$$$ConfirmationLink$$$", BaseUrl + "/confirm-account.aspx?guid=" + GUID + "&amp;username=" + UserName);
                return emailfile.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sr.Dispose();
            }
        }

        public string populateForgotPasswordEmailTemplate(string afdsl_FilePath, string UserName, string BaseUrl, string GUID)
        {
            StreamReader sr = new StreamReader(afdsl_FilePath);
            try
            {
                string emailfile = sr.ReadToEnd();
                emailfile = emailfile.Replace("$$$UserName$$$", UserName);
                emailfile = emailfile.Replace("$$$ResetLink$$$", BaseUrl + "/reset-password.aspx?guid=" + GUID + "&amp;username=" + UserName);
                return emailfile.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sr.Dispose();
            }
        }

        public bool isCorrectEmail(string email)
        {
            bool isValid;
            Match match = regex.Match(email);
            if (match.Success)
            {
                isValid = true;
                return isValid;
            }
            else
            {
                isValid = false;
                return isValid;
            }
        }
    }
}
