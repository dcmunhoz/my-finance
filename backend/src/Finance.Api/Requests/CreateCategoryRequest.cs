namespace Finance.Api.Requests;

public record CreateCategoryRequest(string Name, 
                                    string Color, 
                                    Guid? ParentId);