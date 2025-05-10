namespace MindMateJourney.Application.Services;

public interface IMailService
{
    public Task SendEmailAsync(string toEmail, string userName, string verificationCode);
}