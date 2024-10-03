using Core.Aggregate;

namespace Finance.Domain.Aggregates;

public class Category : Entity, IAggregateRoot
{
    public Category(Guid id, string name, string color, Guid? parentId)
    {
        Id = id;
        Name = name;
        Color = color;
        ParentId = parentId;
    }

    public string Name { get; private set; }    
    public string Color { get; private set; }
    public Guid? ParentId { get; private set; }
    
}