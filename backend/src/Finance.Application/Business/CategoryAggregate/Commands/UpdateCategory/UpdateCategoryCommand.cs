using Finance.Contracts.Categories.Requests.Category;
using Finance.Domain.Aggregates;
using MediatR;

namespace Finance.Application.Business.CategoryAggregate.Commands.UpdateCategory;

public record UpdateCategoryCommand(Guid Id, string Name, string Color) : IRequest<Category?>;