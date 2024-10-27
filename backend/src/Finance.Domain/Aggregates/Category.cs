using Core.Aggregate;

namespace Finance.Domain.Aggregates;

public class Category : Entity, IAggregateRoot
{
    private readonly List<Category> _childrens;

    protected Category()
    {
        _childrens = new List<Category>();
    }
    
    public Category(Guid id, string name, string color, Guid? parentId = null) : base()
    {
        Id = id;
        Name = name;
        Color = color;
        ParentId = parentId;
    }

    public string Name { get; init; }    
    public string Color { get; init; }
    public Guid? ParentId { get; init; }
    public IReadOnlyCollection<Category> Childrens => _childrens;
    
}