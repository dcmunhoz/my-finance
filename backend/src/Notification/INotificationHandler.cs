namespace Notification;

public interface INotificationHandler
{
    INotificationHandler WithTitle(string title);
    INotificationHandler WithDescription(string description);
    bool HasNotification();
    IReadOnlyCollection<Notification> GetNotifications();
    void Raise();
}