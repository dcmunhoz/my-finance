namespace Notification;

public class Notification
{
    public string Title { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public NotificationDetail[] Details { get; set; }
}

public class NotificationDetail
{
    public string Title { get; set; }
    public string Description { get; set; }
}