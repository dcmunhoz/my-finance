using MediatR;
using Result;

namespace Common.Application.Commands;

public abstract class AuthenticatedCommand<TResult> : BaseCommand<Result<TResult>>
{
    public Guid UserId { get; set; }
}