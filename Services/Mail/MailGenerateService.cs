using System.IO;
using Microsoft.Extensions.Localization;
using webapi_example_services.Models.Common;

namespace webapi_example_services.Services.Mail
{
    public class MailGenerateService
    {

        public MailGenerateService()
        {

        }

        public MailContent generateVerifyMail(string toEmail, string companyName, string verifyCode)
        {

            string body = readHtmlContentFromFile("Resources/MailTemplate/verify-code.html");

            // var builder = new BodyBuilder();
            // var pathImage = Path.Combine(Misc.GetPathOfExecutingAssembly(), "Image.png");
            // var image = builder.LinkedResources.Add(pathLogoFile);

            // image.ContentId = MimeUtils.GenerateMessageId();

            // builder.HtmlBody = string.Format(@"<p>Hey!</p><img src=""cid:{0}"">", image.ContentId);

            // message.Body = builder.ToMessageBody();

            MailContent content = new MailContent
            {
                To = toEmail,
                Subject = $"{companyName} send you verify code",
                Body = body
                    .Replace("{{verifyTitle}}", "abc")
                    .Replace("{{verifyCode}}", verifyCode)
            };
            return content;
        }


        private string readHtmlContentFromFile(string path)
        {
            string htmlContent;
            using (StreamReader SourceReader = System.IO.File.OpenText(path))
            {
                htmlContent = SourceReader.ReadToEnd();
            }
            return htmlContent;
        }
    }
}