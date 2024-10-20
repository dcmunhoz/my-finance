namespace Finance.Api.Requests.Category;

public record CreateCategoryRequest(string Name,
                                    string Color,
                                    Guid? ParentId);