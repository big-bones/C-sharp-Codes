using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using MailKit.Net;
using MimeKit;
using System.Net;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly string _gmailUser = "systemgenerated90@gmail.com"; 
        private readonly string _gmailPassword = "SystemGeneratedMail@1032"; 

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult> Get()
        {
            return BadRequest(new
            {
                success = false,
                message = "User not found"
            });
        }

        private async Task SendPasswordResetEmailAsync(string toEmail, string resetLink)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.Credentials = new NetworkCredential(_gmailUser, "vpvu jamf xvlb qgtm");
                client.EnableSsl = true; 

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(_gmailUser),
                    Subject = "Password Reset Request",
                    Body = resetLink,
                    IsBodyHtml = false 
                };

                mailMessage.To.Add(toEmail);

                try
                {
                    await client.SendMailAsync(mailMessage);
                }
                catch (SmtpException ex)
                {
                    // Handle SMTP exceptions
                    Console.WriteLine($"SMTP Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Handle general exceptions
                    Console.WriteLine($"General Error: {ex.Message}");
                }
            }
        }


    }
}

/*
 

{

  "success" : true,
  "message" : "Successfull login",
  "body" : {
            "id" : 1234,
            "email" : loginexample@gmail.com
         },
  "token" : "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."

}

{
    "success" : false,
    "message" : "Unsuccessful Login Attempt",
    "error" : [{
                  message : "Invalid User Credentials"
               },
            ]
}
 
{
    "success" : true,
    "message" : "Registration Successfull"
    "userId" : 12345
    "token" : "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}

{
    "success" : false,
    "message" : "Registration Unsuccessful",
    "error" : [{
                  message : "Password length insufficient"
               },
            ]
}
 
 
 
 */