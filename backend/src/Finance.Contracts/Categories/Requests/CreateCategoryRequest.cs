using Finance.Domain.Common.Enums;

namespace Finance.Contracts.Categories.Requests;

public record CreateCategoryRequest(MovementType Type, string Description, string Color, Guid? ParentId);