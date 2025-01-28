using Common.Application.Commands;
using Finance.Application.Common.Errors;
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
        if (request.ParentId.HasValue
            && !await _repository.ExistsAsync(w => 
                w.Id.Equals(request.ParentId.Value), cancellationToken))
            return Error.Category.ParentNonExistent;

        if (await _repository.ExistsAsync(w => 
                w.Description.Trim().Equals(request.Description.Trim()), cancellationToken))
            return Error.Category.CategoryWithSameDescription;
        
        Category category = new(request.Type, request.Description, request.Color, request.ParentId, request.UserId);

        await _repository.CreateAsync(category, cancellationToken);
        await _repository.CommitAsync(cancellationToken);

        return category.Id;
    }
}