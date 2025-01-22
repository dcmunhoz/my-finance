using MediatR;

namespace Finance.Application.Business.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(string Description, string Color, Guid? ParentId) : IRequest<Guid>;