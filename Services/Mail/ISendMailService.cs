using System.Threading.Tasks;
using webapi_example_services.Models.Common;

namespace webapi_example_services.Services.Mail
{
    public interface ISendMailService
    {
        Task SendMail(MailContent mailContent);

        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}