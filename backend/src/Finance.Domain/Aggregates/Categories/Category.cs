using System.Diagnostics.CodeAnalysis;
using Common.Domain;
using Finance.Domain.Common.Enums;

namespace Finance.Domain.Aggregates.Categories;

public class Category : AggregateRoot, IAggregateRoot
{
    // EF Core
    [ExcludeFromCodeCoverage]
    protected Category() { }
    
    public Category(MovementType type, string description, string color, Guid? parentId, Guid userId)
    {
        Id = Guid.NewGuid();
        Description = description;
        Color = color;
        ParentId = parentId;
        UserId = userId;
        Level = parentId.HasValue ? 2 : 1;
    }

    public MovementType Type { get; private set; }
    public string Description { get; private set; }
    public string Color { get; private set; }
    public Guid? ParentId { get; private set; }
    public Category? Parent { get; }
    public List<Category> Children { get; }
    public int Level { get; private set; }
    public Guid UserId { get; private set; }

    public void Update(string description, string color)
    {
        Description = description;
        Color = color;
    }
}