namespace App.Domain.Core
{
    public interface IMailSender
    {
        void Send(string message, string email);
    }
}