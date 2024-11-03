namespace Finance.Contracts.Categories.Responses.Category;

public sealed record CategoryResponse(Guid Id,
                                      string Name,
                                      string Color,
                                      IEnumerable<ChildrenCategoryResponse>? Childrens = null);
                                            
public sealed record ChildrenCategoryResponse(Guid Id,
                                              string Name,
                                              string Color);