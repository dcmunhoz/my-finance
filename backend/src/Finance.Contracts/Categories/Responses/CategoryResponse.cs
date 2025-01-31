using Finance.Domain.Categories;
using Finance.Domain.Categories.Enums;

namespace Finance.Contracts.Categories.Responses;

public record ParentCategoryResponse(Guid Id, string Description, string Color);

public class CategoryResponse
{
    public Guid Id { get; set; }
    public CategoryType Type { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public ParentCategoryResponse? Parent { get; set; }
    
    public static implicit operator CategoryResponse?(Category? category)
        => category is null ? null :  new CategoryResponse
        {
            Id = category.Id,
            Description = category.Description,
            Color = category.Color,
            Type = category.Type,
            Parent = category.Parent is null
                ? null
                : new ParentCategoryResponse(
                    category.Parent.Id, 
                    category.Parent.Description, 
                    category.Parent.Color),
        };
}