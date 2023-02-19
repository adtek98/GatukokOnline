namespace WebApp.Services
{
    public class NullMailServices : IMailServices
    {
        private readonly ILogger<NullMailServices> logger;

        public NullMailServices(ILogger<NullMailServices> logger)
        {
            this.logger = logger;
        }
        public void SendMessage(string sender, string name, string subject, string message)
        {
            logger.LogInformation($"From: {sender}, Name: {name}, Subject: {subject}, Message: {message}");
        }
    }
}
