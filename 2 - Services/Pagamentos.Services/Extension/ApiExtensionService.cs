
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pagamentos.Infrastructure;
using Pagamentos.Service.Pagamento;
using Pagamentos.Service.ProcessarPagamento;
using Pagamentos.Shared.RabbitMq;
using System;

namespace Pagamentos.Service.Extension
{
    public static class ApiExtensionService
    {
        public static WebApplication WebApplicationBuilderExtension(this WebApplicationBuilder builder)
        {

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<PagamentoDbContext>(opt =>
                            opt.UseInMemoryDatabase("PagamentosDB"));

            builder.Services.AddHandlers();


            builder.Services.AddScoped<RabbitMqClient>();

            builder.Services.AddScoped<IPagamentoService, PagamentoService>();
            builder.Services.AddScoped<IProcessarPagamentoService, ProcessarPagamentoService>();

            var app = builder.Build();



            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapOpenApi();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            RabbitMqSubscriber.Configure(app.Services);

            return app;

        }
    }
}
