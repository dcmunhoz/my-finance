namespace Finance.Contracts.Requests.Category;

public record CreateCategoryRequest(string Name,
                                    string Color,
                                    Guid? ParentId);