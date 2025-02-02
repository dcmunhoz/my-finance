using Common.Application.Commands;
using Finance.Domain.Common.Enums;

namespace Finance.Application.Business.Reasons.Commands.CreateReason;

public class CreateReasonCommand : AuthenticatedCommand<Guid>
{
    public MovementType Type { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
}