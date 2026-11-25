using FlexibleNotification.Domain.Enums;

namespace FlexibleNotification.Domain.Models
{
    public class NotificationMessage
    {
        public NotificationType Type { get; set; }
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
