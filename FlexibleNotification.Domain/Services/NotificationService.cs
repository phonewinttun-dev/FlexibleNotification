using FlexibleNotification.Domain.Interfaces;
using FlexibleNotification.Domain.Models;
using FlexibleNotification.Shared;

namespace FlexibleNotification.Domain.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IEnumerable<INotificationProvider> _providers;

        public NotificationService(IEnumerable<INotificationProvider> providers)
        {
            _providers = providers;
        }

        public async Task<Result> SendNotificationAsync(NotificationMessage message)
        {
            var provider = _providers.FirstOrDefault(p => p.Type == message.Type);
            if (provider == null)
            {
                return new Result
                {
                    IsSuccess = false,
                    Message = $"Notification channel '{message.Type}' is not supported."
                };
            }

            return await provider.SendAsync(message);
        }
    }
}
