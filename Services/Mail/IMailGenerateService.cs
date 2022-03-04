using webapi_example_services.Models.Common;

namespace webapi_example_services.Services.Mail
{
    public interface IMailGenerateService
    {
        MailContent generateVerifyMail(string toEmail, string companyName, string verifyCode);
    }
}