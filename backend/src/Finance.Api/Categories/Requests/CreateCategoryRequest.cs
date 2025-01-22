namespace Finance.Api.Categories.Requests;

public record CreateCategoryRequest(string Description, string Color, Guid? ParentId);