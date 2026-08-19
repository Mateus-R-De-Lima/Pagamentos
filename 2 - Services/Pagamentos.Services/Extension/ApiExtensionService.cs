
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pagamentos.Domain.Repositories.Comprovantes;
using Pagamentos.Domain.Repositories.Pagamentos;
using Pagamentos.Infrastructure;
using Pagamentos.Infrastructure.DataAccess;
using Pagamentos.Infrastructure.Mongo;
using Pagamentos.Service.Comprovante;
using Pagamentos.Service.Pagamento;
using Pagamentos.Service.ProcessarPagamento;
using Pagamentos.Shared.AzureBlobStorageService;
using Pagamentos.Shared.RabbitMq;
using System;

namespace Pagamentos.Service.Extension
{
    public static class ApiExtensionService
    {
        public static IServiceCollection AddPagamentosServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PagamentoDbContext>(opt =>
                            opt.UseInMemoryDatabase("PagamentosDB"));

            services.AddHandlers();
            services.AddScoped<RabbitMqClient>();

            services.Configure<MongoSettings>(configuration.GetSection("MongoSettings"));

            services.AddSingleton<MongoContext>();

            services.AddScoped<IPagamentosReadOnlyRepository, PagamentoRepository>();
            services.AddScoped<IPagamentoUpdateOnlyRepository, PagamentoRepository>();
            services.AddScoped<IPagamentoWriteOnlyRepository, PagamentoRepository>();
            services.AddScoped<IComprovanteWriteOnlyRepository, ComprovanteRepository>();

            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<IProcessarPagamentoService, ProcessarPagamentoService>();

            services.AddScoped(x =>
            {
                var config = x.GetRequiredService<IConfiguration>();

                var connectionString =
                    config["AzureStorage:ConnectionString"];

                return new BlobServiceClient(connectionString);
            });

            services.AddScoped<IComprovanteService, EnviarComprovanteService>();

            services.AddScoped<IDeletarComprovanteService, DeletarComprovanteService>();

            services.AddScoped<ISalvarComprovanteService, SalvarComprovanteService>();

            services.Configure<AzureStorageSettings>(configuration.GetSection("AzureStorage"));

            services.AddScoped<IAzureBlobStorageService, AzureBlobStorageService>();

            return services;
        }

        public static WebApplication WebApplicationBuilderExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddPagamentosServices(builder.Configuration);

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
