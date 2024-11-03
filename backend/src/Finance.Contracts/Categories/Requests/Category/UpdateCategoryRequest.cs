namespace Finance.Contracts.Categories.Requests.Category;

public record UpdateCategoryRequest(string Name,
                                    string Color,
                                    Guid? ParentId);