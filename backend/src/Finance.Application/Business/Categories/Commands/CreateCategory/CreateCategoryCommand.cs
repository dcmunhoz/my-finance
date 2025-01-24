using Common.Application.Commands;
using MediatR;
using Result;

namespace Finance.Application.Business.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : AuthenticatedCommand<Guid>
{
    public string Description { get; set; }
    public string Color { get; set; }
    public Guid? ParentId { get; set; }
}