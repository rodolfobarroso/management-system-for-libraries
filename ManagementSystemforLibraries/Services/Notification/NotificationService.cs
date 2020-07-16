using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Services
{
    public class NotificationService
    {
        private readonly ISession _session;

        public NotificationService(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public void AddNotification(Notification notification)
        {
            var notifications = GetNotifications().ToList();

            notifications.Add(notification);

            _session.SetString(nameof(NotificationService), JsonSerializer.Serialize(notifications));
        }

        public IEnumerable<Notification> PopAll()
        {
            var notifications = GetNotifications();

            _session.Remove(nameof(NotificationService));

            return notifications;
        }

        private IEnumerable<Notification> GetNotifications()
        {
            var notificationsString = _session.GetString(nameof(NotificationService));

            if (string.IsNullOrWhiteSpace(notificationsString))
                return new List<Notification>();

            var notifications = JsonSerializer.Deserialize<IEnumerable<Notification>>(notificationsString);

            return notifications;
        }
    }
}
