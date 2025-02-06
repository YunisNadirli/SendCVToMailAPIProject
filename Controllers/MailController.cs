using dlt_CV_sender_email.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace dlt_CV_sender_email.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        MailService mailService = new MailService();
        [HttpPost]
        public IActionResult Send(string head, string body)
        {
            string message = mailService.SendMail(head, body);
            return Ok(message);
        }
        [HttpPost("SendWithFile")]
        public IActionResult SendWithFile(string head, string body, IFormFile file)
        { 
            string message = mailService.SendMailWithFile(head, body, file);
            return Ok(message);
        }
    }
}
