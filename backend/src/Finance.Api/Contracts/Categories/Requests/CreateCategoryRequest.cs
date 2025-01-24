namespace Finance.Api.Contracts.Categories.Requests;

public record CreateCategoryRequest(string Description, string Color, Guid? ParentId);