using Common.Application.Commands;
using Finance.Application.Common.Interface.Repository;
using Finance.Domain.Categories;
using Result;

namespace Finance.Application.Business.Categories.Commands.CreateCategory;

public class CreateCategoryHandler : ICommandHandler<CreateCategoryCommand, Guid>
{
    private readonly ICategoryRepository _repository;
    
    public CreateCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = new(request.Description, request.Color, request.ParentId, Guid.Empty);

        await _repository.CreateAsync(category, cancellationToken);
        await _repository.CommitAsync(cancellationToken);

        return category.Id;
    }
}