namespace App.Domain.Services
{
    using System;
    using Core;

    public interface IMailService
    {
        void Send(string message, string email);
    }

    public class MailService : IMailService
    {
        private readonly IMailSender mailSender;

        private readonly ILogger logger;

        public MailService(IMailSender mailSender, ILogger logger)
        {
            this.mailSender = mailSender;
            this.logger = logger;
        }

        public void Send(string message, string email)
        {
            this.EnsureMailIsValid(email);

            this.mailSender.Send(message, email);

            this.logger.Log($"Mail was sent to {email}");
        }

        private void EnsureMailIsValid(string email)
        {
            if (!email.Contains("@"))
            {
                throw new ArgumentException("Email is not valid!");
            }
        }
    }
}