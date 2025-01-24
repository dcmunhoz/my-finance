using FluentValidation;
using Result;

namespace Common.Application.Validations;

public static class ValidationResultErrorExtension
{
    public static IRuleBuilderOptions<T, TProperty> WithResultError<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string title, string message )
    {
        rule.WithMessage(message)
            .WithState(x => new ResultError(title, message));

        return rule;
    }
}