using Ecommerce.Application.Services;

namespace Ecommerce.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendAsync(string to, string subject, string body)
        {
            Console.WriteLine($"[EMAIL] To: {to}, Subject: {subject}, Body: {body}");
            return Task.CompletedTask;
        }
    }
}
