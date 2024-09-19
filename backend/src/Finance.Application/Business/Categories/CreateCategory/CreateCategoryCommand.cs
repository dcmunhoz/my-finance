using MediatR;

namespace Finance.Application.Business.Categories.CreateCategory;

public record CreateCategoryCommand(string Name, 
                                    string Color, 
                                    Guid? ParentId) : IRequest;