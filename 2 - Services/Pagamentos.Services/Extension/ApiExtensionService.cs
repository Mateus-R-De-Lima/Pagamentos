
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));        

          
            builder.Services.AddSingleton<MongoContext>();

            // Repositories
            builder.Services.AddScoped<IPagamentosReadOnlyRepository, PagamentoRepository>();
            builder.Services.AddScoped<IPagamentoUpdateOnlyRepository, PagamentoRepository>();
            builder.Services.AddScoped<IPagamentoWriteOnlyRepository, PagamentoRepository>();

            builder.Services.AddScoped<IPagamentoService, PagamentoService>();
            builder.Services.AddScoped<IProcessarPagamentoService, ProcessarPagamentoService>();

       

            builder.Services.AddScoped(x =>
            {
                var configuration = x.GetRequiredService<IConfiguration>();

                var connectionString =
                    configuration["AzureStorage:ConnectionString"];

                return new BlobServiceClient(connectionString);
            });

            builder.Services.AddScoped<IComprovanteService, EnviarComprovanteService>();

            builder.Services.AddScoped<IDeletarComprovanteService, DeletarComprovanteService>();

            builder.Services.Configure<AzureStorageSettings>(builder.Configuration.GetSection("AzureStorage"));

            builder.Services.AddScoped<IAzureBlobStorageService, AzureBlobStorageService>();

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
