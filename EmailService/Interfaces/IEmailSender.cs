﻿using EmailService.Model;

namespace EmailService.Interfaces {
    public interface IEmailSender {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}