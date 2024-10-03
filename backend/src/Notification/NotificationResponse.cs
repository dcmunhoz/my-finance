namespace Notification;

public class Notification
{
    public string Title { get; set; }
    public string Description { get; set; }
    public NotificationDetail[] Details { get; set; }
}

public class NotificationDetail
{
    public string Title { get; set; }
    public string Description { get; set; }
}