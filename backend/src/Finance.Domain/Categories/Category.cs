using System.Diagnostics.CodeAnalysis;
using Finance.Domain.Categories.Enums;

namespace Finance.Domain.Categories;

public class Category
{
    // EF Core
    [ExcludeFromCodeCoverage]
    protected Category() { }
    
    public Category(CategoryType type, string description, string color, Guid? parentId, Guid userId)
    {
        Description = description;
        Color = color;
        ParentId = parentId;
        UserId = userId;
    }

    public Guid Id { get; }
    public CategoryType Type { get; private set; }
    public string Description { get; private set; }
    public string Color { get; private set; }
    public Guid? ParentId { get; private set; }
    public Category? Parent { get; }
    public Guid UserId { get; private set; }

    public void Update(string description, string color)
    {
        Description = description;
        Color = color;
    }
}