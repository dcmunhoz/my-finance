using Finance.Domain.Categories.Enums;

namespace Finance.Contracts.Categories.Requests;

public record CreateCategoryRequest(CategoryType Type, string Description, string Color, Guid? ParentId);