using Common.Application.Commands;
using FluentValidation;
using MediatR;
using Result;

namespace Common.Application.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse> 
    where TResponse : IValidatableResult
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var validator = _validators.First();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
                return await next();
            
            return (dynamic)validationResult.Errors.Select(s => s.CustomState as ResultError).ToList();
        }
        
        return await next();
    }
}