using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SIGO.Normas.Domain.DTO.Normas;
using System;
using System.Text;

namespace SIGO.Normas.Infrastructure.CrossCutting.EventBus.Senders
{
    public class NormaUpdateSender : INormaUpdateSender
    {
        private readonly string _hostname;
        private readonly int _port;
        private readonly string _password;
        private readonly string _username;
        private readonly string _queueName;
        private readonly string _virtualHost;

        private IConnection _connection;

        public NormaUpdateSender(IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            _hostname = rabbitMqOptions.Value.Hostname;
            _port = rabbitMqOptions.Value.Port;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;
            _queueName = rabbitMqOptions.Value.QueueName;
            _virtualHost = rabbitMqOptions.Value.VirtualHost;

            CreateConnection();
        }

        public void EnviarNormaAtualizada(NormaEvento normaEvento)
        {
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var json = JsonConvert.SerializeObject(normaEvento);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
                }
            }
        }

        private void CreateConnection()
        {
            try
            {
                Console.WriteLine($"HostName: {_hostname}");
                Console.WriteLine($"VirtualHost: {_virtualHost}");
                Console.WriteLine($"Port: {_port}");
                Console.WriteLine($"UserName: {_username}");
                Console.WriteLine($"Password: {_password}");
                Console.WriteLine($"QueueName: {_queueName}");

                var factory = new ConnectionFactory
                {
                    HostName = _hostname,
                    VirtualHost = _virtualHost,
                    Port = _port,
                    UserName = _username,
                    Password = _password
                };

                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"variavel: {ex.Message}");
                Console.WriteLine($"Não foi possível estabelecer a conexão: {ex.Message}");
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }

            CreateConnection();

            return _connection != null;
        }
    }
}
