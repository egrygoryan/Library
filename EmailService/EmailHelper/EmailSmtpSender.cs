using EmailService.Configuration;
using EmailService.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailService.EmailHelper {
    public class EmailSmtpSender : ISmtpSender {
        private readonly EmailConfiguration _emailConfig;
        public EmailSmtpSender(EmailConfiguration emailConfig) {
            _emailConfig = emailConfig;
        }
        public void SendWithSmtp(MimeMessage emailMessage) {
            using (var client = new SmtpClient()) {
                try {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                    client.Send(emailMessage);
                } catch {
                    throw;
                } finally {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        public async Task SendWithSmtpAsync(MimeMessage emailMessage) {
            using (var client = new SmtpClient()) {
                try {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                    await client.SendAsync(emailMessage);
                } catch {
                    throw;
                } finally {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
