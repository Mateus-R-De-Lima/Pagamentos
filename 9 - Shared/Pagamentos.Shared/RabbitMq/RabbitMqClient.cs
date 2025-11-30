using RabbitMQ.Client;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;

namespace Pagamentos.Shared.RabbitMq
{
    public class RabbitMqClient 
    {
        public void Publish<T>(T message)
        {
            // Criando a factory com valores literais
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "admin",
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var queueName = typeof(T).Name;
            channel.QueueDeclare(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(
                exchange: "",
                routingKey: queueName,
                basicProperties: null,
                body: body);
        }
    }
}
