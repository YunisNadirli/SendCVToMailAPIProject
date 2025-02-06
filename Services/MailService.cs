using Microsoft.AspNetCore.Components.Forms;
using dlt_CV_sender_email.Exceptions;
using System.Net;
using System.Net.Mail;


namespace dlt_CV_sender_email.Services
{
    public class MailService
    {
        FileService fileService = new FileService();
        public string SendMail(string head, string text)
        {
            try
            {
                string from = "yuni333nadir@gmail.com";
                string password = "fpsq tjsc qupu riew";
                string to = "yunisnadirli7@gmail.com";
                var message = new MailMessage(from, to)
                {
                    Subject = head,
                    Body = text,
                    IsBodyHtml = false,
                };
                var client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(from,password),
                    UseDefaultCredentials = false,
                    EnableSsl = true
                };
                
                client.Send(message);   
                return "Mail send";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
        public string SendMailWithFile(string head, string text, IFormFile file)
        {
            try
            {
                string from = "yuni333nadir@gmail.com";
                string password = "fpsq tjsc qupu riew";
                string to = "yunisnadirli7@gmail.com";
                var message = new MailMessage(from, to)
                {
                    Subject = head,
                    Body = text,
                    IsBodyHtml = false,
                };
                string path = fileService.Upload(file);
                Attachment attachment = new Attachment(path);
                message.Attachments.Add(attachment);
                var client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(from, password),
                    UseDefaultCredentials = false,
                    EnableSsl = true
                };

                client.Send(message);
                return "Mail send";
            }
            catch (InvalidExtentionException e)
            {
                return e.Message;
            }
            catch (BigSizeException e)
            {
                return e.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
