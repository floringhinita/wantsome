namespace Domain
{
    public interface IMailSender
    {
        void Send(string message);
    }
}