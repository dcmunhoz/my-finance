namespace Finance.Contracts.Categories.Requests.Category;

public record CreateCategoryRequest(string Name,
                                    string Color,
                                    Guid? ParentId);