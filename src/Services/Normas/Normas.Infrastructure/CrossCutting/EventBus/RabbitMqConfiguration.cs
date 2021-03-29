namespace SIGO.Normas.Infrastructure.CrossCutting.EventBus
{
    public class RabbitMqConfiguration
    {
        public string Hostname { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string VirtualHost { get; set; }

        public string QueueName { get; set; }

        public bool Enabled { get; set; }
    }
}
