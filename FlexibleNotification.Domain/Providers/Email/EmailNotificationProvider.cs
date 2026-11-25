using FlexibleNotification.Domain.Enums;
using FlexibleNotification.Domain.Interfaces;
using FlexibleNotification.Domain.Models;
using FlexibleNotification.Shared;

namespace FlexibleNotification.Domain.Providers.Email
{
    public class EmailNotificationProvider : INotificationProvider
    {
        public NotificationType Type => NotificationType.Email;
        private readonly INotificationProvider _emailService;

        public EmailNotificationProvider(INotificationProvider emailService)
        {
            _emailService = emailService;
        }

        //public async Task<Result> SendAsync(NotificationMessage message)
        //{
        //    try
        //    {
        //        Console.WriteLine($"Simulated: Email sent to {message.To} with subject '{message.Subject}'");
        //        return await Task.FromResult(new Result
        //        {
        //            IsSuccess = true,
        //            Message = $"Email sent to {message.To}"
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error sending email: {ex.Message}");
        //        return new Result { IsSuccess = false, Message = $"Failed to send email: {ex.Message}" };
        //    }
        //}

        public async Task<Result> SendAsync(NotificationMessage message)
        {
            try
            {
                var email = await _emailService.SendAsync(message);
                return await Task.FromResult(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return new Result { IsSuccess = false, Message = $"Failed to send email: {ex.Message}" };
            }
        }
    }
}
