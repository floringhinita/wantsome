namespace App.Infrastructure.Mail
{
    using System;
    using Domain.Core;

    public class MailSender : IMailSender
    {
        public void Send(string message, string email)
        {
            // dummy implementation

            Console.WriteLine("SEND EMAIL");
        }
    }
}
