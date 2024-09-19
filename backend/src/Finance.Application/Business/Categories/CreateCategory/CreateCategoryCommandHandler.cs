using Finance.Application.Repositories;
using Finance.Domain.Aggregates;
using MediatR;

namespace Finance.Application.Business.Categories.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    
    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(Guid.NewGuid(), request.Name, request.Color, request.ParentId);
        
        await _categoryRepository.CreateCategoryAsync(category, cancellationToken);
    }
}