using Microsoft.Extensions.DependencyInjection;
using Pagamentos.Shared.NotificationHandler;
using System.Reflection;

namespace Pagamentos.Service.Extension
{
    public static class HandlerExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var handlers = assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(INotificationHandler<>)));

            foreach (var handler in handlers)
            {
                var interfaceType = handler.GetInterfaces()
                    .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(INotificationHandler<>));

                services.AddScoped(interfaceType, handler);
            }

            return services;
        }
    }
}
