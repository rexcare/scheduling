using Microsoft.DSX.ProjectTemplate.Data.Abstractions;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Microsoft.DSX.ProjectTemplate.Data.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public Task SendEmailAsync(string from, string to, string subject, string body)
        {
            _logger.LogInformation($"From {from} | To: {to} | Subject: '{subject}' | Body: '{body}'");

            return Task.CompletedTask;
        }
    }
}
