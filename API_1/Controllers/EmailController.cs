
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization;

[ApiController]
[Route("api/email")]
public class EmailController : ControllerBase
{
    [HttpPost("send")]


    public IActionResult Send([FromBody] EmailDto dto)
    {
        Console.WriteLine($"DTO TO VALUE: '{dto.to}'");
        Console.WriteLine($"LENGTH: {dto.to?.Length}");
        var client = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("YOUR_EMAIL", "YOUR_PASSWORD"),
            EnableSsl = true
        };

        var mail = new MailMessage
        {
            From = new MailAddress("comp.gur@gmail.com"),
            Subject = dto.Subject,
            Body = dto.Body,
            IsBodyHtml = false
        };

        mail.To.Add(dto.to);

        client.Send(mail);

        return Ok();
    }
}


public class EmailDto
{
    [JsonPropertyName("to")]
    public string to { get; set; }

    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    [JsonPropertyName("body")]
    public string Body { get; set; }
}