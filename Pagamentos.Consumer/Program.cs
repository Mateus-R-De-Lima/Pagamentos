using Pagamentos.Service.Extension;
using Pagamentos.Shared.ModelNotication;
using Pagamentos.Shared.RabbitMq;

var builder = WebApplication.CreateBuilder(args);

RabbitMqSubscriber.Subscribe<PagamentoNotification>();

ApiExtensionService.WebApplicationBuilderExtension(builder);