namespace Pagamentos.Shared.NotificationHandler
{
    public interface INotificationHandler<T>
    {
        Task HandleAsync(T notification);
    }
}
