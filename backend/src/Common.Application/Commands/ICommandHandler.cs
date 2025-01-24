using MediatR;
using Result;

namespace Common.Application.Commands;

public interface ICommandHandler<TRequest, TResult> : IRequestHandler<TRequest, Result<TResult>> 
    where TRequest : IRequest<Result<TResult>>;