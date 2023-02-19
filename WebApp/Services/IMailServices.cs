namespace WebApp.Services
{
    public interface IMailServices
    {
        void SendMessage(string sender, string name, string subject, string message);
    }
}