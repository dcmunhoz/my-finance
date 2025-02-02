using Finance.Domain.Common.Enums;

namespace Finance.Contracts.Categories.Responses;


public record ChildrenResponse(Guid Id, string Description, string Color);

public class CategoriesResponse
{
    public Guid Id { get; set; }
    public MovementType Type { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public IEnumerable<ChildrenResponse> Childrens { get; set; }
}