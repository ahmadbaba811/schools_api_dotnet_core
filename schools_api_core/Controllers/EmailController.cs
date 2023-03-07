using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using schools_api_core.Configuration;
using schools_api_core.Data;
using schools_api_core.Models;

namespace schools_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        /*private readonly schoolDbContext _context;
        public EmailController(schoolDbContext context) => _context = context;*/

        //SEND EMAIL
        [HttpPost("send_email")]
        public IActionResult SendEmail(EmailClass mail)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("ahmadub81@gmail.com"));
            email.To.Add(MailboxAddress.Parse(mail.To));
            email.Subject = mail.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = mail.Body };
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("ahmadub81@gmail.com", "ykvmzxbtdlhdjybo");
            var x = smtp.Send(email);
            smtp.Disconnect(true);
            if (x == null) return BadRequest();
            return Ok("success");
           
        }

    }
}
