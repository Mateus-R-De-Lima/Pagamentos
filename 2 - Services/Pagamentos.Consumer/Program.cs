using Pagamentos.Service.Extension;

var builder = WebApplication.CreateBuilder(args);

ApiExtensionService.WebApplicationBuilderExtension(builder);