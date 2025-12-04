using Pagamentos.Shared.NotificationHandler;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

namespace Pagamentos.Shared.RabbitMq
{
    public class RabbitMqSubscriber
    {
        private static IServiceProvider _serviceProvider;

        public static void Configure(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static void Subscribe<T>()
        {
            var factory = Factory.ConfigFactory();

            var queue = typeof(T).Name;

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queue,
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

            channel.ExchangeDeclare("trigger", ExchangeType.Fanout);
            channel.QueueBind(queue, "trigger", "");

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (sender, args) =>
            {
                using var scope = _serviceProvider.CreateScope();
                var json = Encoding.UTF8.GetString(args.Body.ToArray());
                var message = JsonSerializer.Deserialize<T>(json);

                var handler = scope.ServiceProvider.GetRequiredService<INotificationHandler<T>>();
                await handler.HandleAsync(message);

                channel.BasicAck(args.DeliveryTag, false);
            };

            channel.BasicConsume(queue, autoAck: false, consumer);
        }

        private static async Task ProcessEvent<T>(T message)
        {
            var handlerInterface = typeof(INotificationHandler<T>);

            // Procurar classe que implementa INotificationHandler<T>
            var handlerType = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .FirstOrDefault(t =>
                    handlerInterface.IsAssignableFrom(t) &&
                    !t.IsInterface &&
                    !t.IsAbstract);

            if (handlerType == null)
                throw new Exception($"Nenhum handler encontrado para {typeof(T).Name}");

            // Instanciar o handler
            var handlerInstance = Activator.CreateInstance(handlerType);

            // Executar HandleAsync
            var method = handlerInterface.GetMethod("HandleAsync");

            await (Task)method.Invoke(handlerInstance, new object[] { message });
        }
    }
}

