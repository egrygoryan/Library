using EmailService.Interfaces;
using EmailService.Model;

namespace EmailService.EmailHelper {
    public class EmailSender : IEmailSender {
        private readonly ICreateMessage _createMessage;
        private readonly ISmtpSender _smtpSender;
        public EmailSender(ICreateMessage createMessage, ISmtpSender smtpSender) {
            _createMessage = createMessage;
            _smtpSender = smtpSender;
        }
        public void SendEmail(Message message) {
            var emailMessage = _createMessage.CreateEmailMessage(message);
            _smtpSender.SendWithSmtp(emailMessage);
        }

        public async Task SendEmailAsync(Message message) {
            var emailMessage = _createMessage.CreateEmailMessage(message);
            await _smtpSender.SendWithSmtpAsync(emailMessage);
        }
    }
}
