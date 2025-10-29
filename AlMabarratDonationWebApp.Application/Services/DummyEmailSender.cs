using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

public class DummyEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // For now, just simulate sending email
        Console.WriteLine($"Sending email to {email}: {subject}");
        return Task.CompletedTask;
    }
}
