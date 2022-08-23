using EmailService.Model;
using MimeKit;

namespace EmailService.Interfaces {
    public interface ICreateMessage {
       public MimeMessage CreateEmailMessage(Message message);
    }
}