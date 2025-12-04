using Pagamentos.Service.Extension;
using Pagamentos.Shared.ModelNotication;
using Pagamentos.Shared.RabbitMq;

var builder = WebApplication.CreateBuilder(args);

var app = ApiExtensionService.WebApplicationBuilderExtension(builder);

RabbitMqSubscriber.Subscribe<PagamentoNotification>();

app.Run();