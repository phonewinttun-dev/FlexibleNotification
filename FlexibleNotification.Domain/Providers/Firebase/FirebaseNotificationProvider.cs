using FlexibleNotification.Domain.Enums;
using FlexibleNotification.Domain.Interfaces;
using FlexibleNotification.Domain.Models;
using FlexibleNotification.Shared;

namespace FlexibleNotification.Domain.Providers.Firebase
{
    public class FirebaseNotificationProvider : INotificationProvider
    {
        public NotificationType Type => NotificationType.Firebase;

        public async Task<Result> SendAsync(NotificationMessage message)
        {
            try
            {
                Console.WriteLine($"Simulated: Firebase push notification sent to device token {message.To} with title '{message.Subject}'");
                return await Task.FromResult(new Result
                {
                    IsSuccess = true,
                    Message = $"Firebase notification sent to {message.To}"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending Firebase notification: {ex.Message}");
                return new Result { IsSuccess = false, Message = $"Failed to send Firebase notification: {ex.Message}" };
            }
        }
    }
}
