using MediatR;
using Result;

namespace Common.Application.Commands;

public class BaseCommand<TResult> : IRequest<TResult>;