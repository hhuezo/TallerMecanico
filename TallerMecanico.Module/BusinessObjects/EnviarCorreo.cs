using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;


namespace TallerMecanico.Module.BusinessObjects
{
    public class EnviarCorreo
    {
        public int EnviarCorreoElectronico(string Correoelectronico, string mensaje, string tema)
        {
            string Host = System.Configuration.ConfigurationManager.AppSettings["NotHost"];
            int Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["NotPort"]);
            string NetWorkEmail = System.Configuration.ConfigurationManager.AppSettings["NotEmail"];
            string NetWrokPassword = System.Configuration.ConfigurationManager.AppSettings["NotPassword"];


            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(Correoelectronico));
            email.From = new MailAddress(NetWorkEmail);
            email.Subject = tema;
            email.Body = mensaje;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = Host;
            smtp.Port = Port;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(NetWorkEmail, NetWrokPassword);

            try
            {
                smtp.Send(email);
                email.Dispose();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 0;

        }
    }
}
