using Pagamentos.Service.Extension;

var builder = WebApplication.CreateBuilder(args);

var app = ApiExtensionService.WebApplicationBuilderExtension(builder);

app.Run();