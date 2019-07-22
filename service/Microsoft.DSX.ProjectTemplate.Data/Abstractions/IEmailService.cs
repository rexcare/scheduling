using System.Threading.Tasks;

namespace Microsoft.DSX.ProjectTemplate.Data.Abstractions
{
    public interface IEmailService
    {
        Task SendEmailAsync(string from, string to, string subject, string body);
    }
}
