using Common.Application.Commands;

namespace Finance.Application.Business.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : AuthenticatedCommand<bool>
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
}