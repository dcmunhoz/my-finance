namespace Notification;

public class NotificationHandler : INotificationHandler
{
    private List<Notification> _notifications;
    private Notification _root;

    public NotificationHandler()
    {
        _notifications = new List<Notification>();
        _root = new Notification();
    }
    
    public IReadOnlyCollection<Notification> GetNotifications() 
        => _notifications.AsReadOnly();
    
    public INotificationHandler WithTitle(string title)
    {
        _root.Title = title;
        return this;
    }

    public INotificationHandler WithDescription(string description)
    {
        _root.Description = description;
        return this;
    }

    public bool HasNotification()
        => _notifications.Any();

    public void Raise()
    {
        _notifications.Add(_root);
        _root = new Notification();
    }
}