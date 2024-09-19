namespace Finance.Domain.Aggregates;

public class Category
{
    public Category(Guid id, string name, string color, Guid? parentId)
    {
        Id = id;
        Name = name;
        Color = color;
        ParentId = parentId;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }    
    public string Color { get; private set; }
    public Guid? ParentId { get; private set; }
    
}