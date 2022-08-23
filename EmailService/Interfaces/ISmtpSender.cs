using MimeKit;

namespace EmailService.Interfaces {
    public interface ISmtpSender {
        void SendWithSmtp(MimeMessage emailMessage);
        Task SendWithSmtpAsync(MimeMessage emailMessage);
    }
}