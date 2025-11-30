
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pagamentos.Infrastructure;
using System;

namespace Pagamentos.Service.Extension
{
    public static class ApiExtensionService
    {
        public static void WebApplicationBuilderExtension(this WebApplicationBuilder builder)
        {

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<PagamentoDbContext>(opt =>
                            opt.UseInMemoryDatabase("PagamentosDB"));

            var app = builder.Build();



            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapOpenApi();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
