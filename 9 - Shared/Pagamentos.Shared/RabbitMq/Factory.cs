using RabbitMQ.Client;

namespace Pagamentos.Shared.RabbitMq
{
    public static class Factory
    {
        public static ConnectionFactory ConfigFactory()
        {
            // Criando a factory com valores literais
            return new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "admin",
            };
        }
    }
}
