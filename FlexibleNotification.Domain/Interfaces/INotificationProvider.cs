using FlexibleNotification.Domain.Enums;
using FlexibleNotification.Domain.Models;
using FlexibleNotification.Shared;

namespace FlexibleNotification.Domain.Interfaces
{
    public interface INotificationProvider
    {
        NotificationType Type { get; }
        Task<Result> SendAsync(NotificationMessage message);
    }
}
