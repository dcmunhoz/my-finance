using FluentValidation;
using MediatR;
using Notification;

namespace Finance.Application.Pipeline;
public class ValidationPipelineBehaviour<TRequest, TResult> : IPipelineBehavior<TRequest, TResult?> where TRequest : IRequest<TResult>
{
    private readonly IValidator<TRequest> _validator;
    private readonly INotificationHandler _notification;

    public ValidationPipelineBehaviour(IValidator<TRequest> validator, INotificationHandler notification)
    {
        _validator = validator;
        _notification = notification;
    }

    public Task<TResult?> Handle(TRequest request, RequestHandlerDelegate<TResult?> next, CancellationToken cancellationToken)
    {
        var result = _validator.Validate(request);
        if (!result.IsValid)
        {
            result.Errors.ForEach(error => 
                _notification.WithDescription(error.ErrorMessage)
                             .Raise());

            return Task.FromResult<TResult?>(default);
        }

        return next();
    }
}
