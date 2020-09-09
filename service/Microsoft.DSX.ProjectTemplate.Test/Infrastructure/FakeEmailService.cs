using Microsoft.DSX.ProjectTemplate.Data.Abstractions;
using System.Threading.Tasks;

namespace Microsoft.DSX.ProjectTemplate.Test.Infrastructure
{
    internal class FakeEmailService : IEmailService
    {
        private int _sentCount;

        public FakeEmailService()
        {
            _sentCount = 0;
        }

        public Task SendEmailAsync(string from, string to, string subject, string body)
        {
            _sentCount++;

            return Task.CompletedTask;
        }

        public int GetSentCount()
        {
            return _sentCount;
        }
    }
}
