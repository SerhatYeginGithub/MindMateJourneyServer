using Microsoft.Extensions.Options;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Caching.Memory;

namespace MindMateJourney.Infrastructure.Services;

public sealed class MailService : IMailService
{
    private readonly MailSettings _mailSettings;
    public MailService(IOptions<MailSettings> options)
    {
        _mailSettings = options.Value;
    }

    public async Task SendEmailAsync(string toEmail, string userName, string verificationCode)
    {

        MailMessage mail = new MailMessage();
        mail.To.Add(toEmail.Trim());
        mail.From = new MailAddress(_mailSettings.From);
        mail.Subject = "Verification Code";
        mail.Body = $"<p>Verification Code : {verificationCode} </p>";
        mail.IsBodyHtml = true;

        SmtpClient smtp = new SmtpClient();
        smtp.Port = _mailSettings.Port; // 25 465
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        smtp.Host = "smtp.gmail.com";
        smtp.Credentials = new NetworkCredential(_mailSettings.From, _mailSettings.Password);
        smtp.Send(mail);
    }

}