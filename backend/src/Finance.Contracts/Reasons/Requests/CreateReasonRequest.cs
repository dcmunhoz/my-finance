namespace Finance.Contracts.Reasons.Requests;

public record CreateReasonRequest(int Type, string Description, string Color);