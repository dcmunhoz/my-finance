using Common.Application.Commands;
using Finance.Application.Common.Errors;
using Finance.Application.Common.Interface.Repository;
using Finance.Domain.Categories;
using Result;

namespace Finance.Application.Business.Categories.Commands.UpdateCategory;

public class UpdateCategoryHandler : ICommandHandler<UpdateCategoryCommand, bool>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        if (await _categoryRepository.ExistsAsync(
                w => w.Id != request.Id && w.Description.Trim().Equals(request.Description.Trim()), cancellationToken))
            return Error.Category.CategoryWithSameDescription;

        var category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);
        if (category is null)
            return Error.Category.CategoryNonExistent;

        category.Update(request.Description, request.Color);
        
        return await _categoryRepository.CommitAsync(cancellationToken);
    }
}