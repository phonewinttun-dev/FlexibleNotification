using FlexibleNotification.Domain.Models;
using FlexibleNotification.Shared;

namespace FlexibleNotification.Domain.Interfaces
{
    public interface INotificationService
    {
        Task<Result> SendNotificationAsync(NotificationMessage message);

    }
}
