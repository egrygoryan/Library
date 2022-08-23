using EmailService.Configuration;
using EmailService.Interfaces;
using EmailService.Model;
using MimeKit;

namespace EmailService.EmailHelper {
    public class EmailCreator: ICreateMessage {
        private readonly EmailConfiguration _emailConfig;
        public EmailCreator(EmailConfiguration emailConfig) {
            _emailConfig = emailConfig;
        }
        public MimeMessage CreateEmailMessage(Message message) {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Email", _emailConfig.From));
            emailMessage.Subject = message.Subject;
            emailMessage.To.AddRange(message.To);
            var bodyBuilder = new BodyBuilder {
                HtmlBody = $"{message.Content}",
            };
            if (message.Attachments?.Any() == true) {
                byte[] fileBytes;
                foreach (var attachment in message.Attachments) {
                    using (var stream = new MemoryStream()) {
                        attachment.CopyTo(stream);
                        fileBytes = stream.ToArray();
                    }
                    bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
                }
            }
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }
    }
}
