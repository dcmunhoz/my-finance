using System.Diagnostics.CodeAnalysis;

namespace Finance.Domain.Categories;

public class Category
{
    // EF Core
    [ExcludeFromCodeCoverage]
    protected Category() { }
    
    public Category(string description, string color, Guid? parentId, Guid userId)
    {
        Description = description;
        Color = color;
        ParentId = parentId;
        UserId = userId;
    }

    public Guid Id { get; }
    public string Description { get; private set; }
    public string Color { get; private set; }
    public Guid? ParentId { get; private set; }
    public Guid UserId { get; private set; }
}