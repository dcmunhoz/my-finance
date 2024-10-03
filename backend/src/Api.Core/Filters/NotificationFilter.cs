using Api.Core.Responses.Error;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Notification;

namespace Api.Core.Filters;

public class NotificationFilter : IAsyncActionFilter
{
    private readonly INotificationHandler _notification;
    
    public NotificationFilter(INotificationHandler notification)
    {
        _notification = notification;
    }
    
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var action = await next();

        if (_notification.HasNotification())
        {
            var notifications = _notification.GetNotifications();
            var response = new ErrorResponse();

            if (notifications.Count > 1)
            {
                response.Title = "Ocorreram erros na solicitação.";
                response.Message = "Veja os detalhes para mais informações dos erros.";

                foreach (var notification in notifications)
                {
                    response.Details.Add(new ErrorDetail
                    {
                        Title = notification.Title, 
                        Message = notification.Description,
                    });
                }
            }
            else
            {
                response.Title = notifications.First().Title;
                response.Message = notifications.First().Description;
            }

            action.Result = new BadRequestObjectResult(response);
        }
    }
}