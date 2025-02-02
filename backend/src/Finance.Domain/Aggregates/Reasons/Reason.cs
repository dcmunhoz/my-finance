using System.Diagnostics.CodeAnalysis;
using Common.Domain;
using Finance.Domain.Common.Enums;

namespace Finance.Domain.Aggregates.Reasons;

public class Reason : AggregateRoot
{
    // EF Core
    [ExcludeFromCodeCoverage]
    protected Reason(){}
    
    public Reason(MovementType type, string description, string color, Guid userId)
    {
        Id = Guid.NewGuid();
        Type = type;
        Description = description;
        Color = color;
        UserId = userId;
    }

    public MovementType Type { get; private set; }
    public string Description { get; private set; }
    public string Color { get; private set; }
    public Guid UserId { get; private set; }
}