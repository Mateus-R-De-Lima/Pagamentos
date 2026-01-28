using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Pagamentos.Shared.RabbitMq
{
    public class RabbitMqClient 
    {
        public void Publish<T>(T message)
        {
            var factory = Factory.ConfigFactory();

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var queueName = typeof(T).Name;
            channel.QueueDeclare(
                queue: queueName,
                durable: false,
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
