using FlexibleNotification.Domain.Enums;
using FlexibleNotification.Domain.Interfaces;
using FlexibleNotification.Domain.Models;
using FlexibleNotification.Shared;
using FluentEmail.Core;

namespace FlexibleNotification.Domain.Services
{
    public class EmailService: INotificationProvider
    {
        public NotificationType Type => NotificationType.Email;

        private readonly IFluentEmail _fluentEmail;

        public EmailService(IFluentEmail fluentEmail)
        {
            this._fluentEmail = fluentEmail;
        }

        public async Task<Result> SendAsync(NotificationMessage message)
        {
            var response = await _fluentEmail
                .To(message.To)
                .Subject(message.Subject)
                .Body(message.Body)
                .SendAsync();

            if(response.Successful is false)
            {
                return new Result { IsSuccess = false, Message = "Fail" };
            }
        
            return new Result { IsSuccess = true, Message = "Success" };
        }
    }
}
