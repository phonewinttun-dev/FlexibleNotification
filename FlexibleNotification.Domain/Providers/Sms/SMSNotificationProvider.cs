using FlexibleNotification.Domain.Enums;
using FlexibleNotification.Domain.Interfaces;
using FlexibleNotification.Domain.Models;
using FlexibleNotification.Shared;

namespace FlexibleNotification.Domain.Providers.Sms
{
    public class SMSNotificationProvider : INotificationProvider
    {
        public NotificationType Type => NotificationType.Sms;

        public async Task<Result> SendAsync(NotificationMessage message)
        {
            try
            {
                Console.WriteLine($"Simulated: SMS sent to {message.To} with message '{message.Body}'");
                return await Task.FromResult(new Result
                {
                    IsSuccess = true,
                    Message = $"SMS sent to {message.To}"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending SMS: {ex.Message}");
                return new Result { IsSuccess = false, Message = $"Failed to send SMS: {ex.Message}" };
            }
        }
    }
}
