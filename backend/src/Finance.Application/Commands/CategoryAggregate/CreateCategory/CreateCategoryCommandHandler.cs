using Finance.Application.Repositories;
using Finance.Domain.Aggregates;
using MediatR;
using Notification;

namespace Finance.Application.Commands.CategoryAggregate.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly INotificationHandler _notificationHandler;
    
    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, INotificationHandler notificationHandler)
    {
        _categoryRepository = categoryRepository;
        _notificationHandler = notificationHandler;
    }
    
    public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        if (request.ParentId.HasValue && await _categoryRepository.GetByIdAsync(request.ParentId.Value) == null)
        {
            _notificationHandler.WithDescription("Categoria pai informada não existe.")
                                .Raise();

            return default;
        }

        var category = new Category(Guid.NewGuid(), request.Name, request.Color, request.ParentId);
                
        await _categoryRepository.CreateAsync(category, cancellationToken);
        await _categoryRepository.UnitOfWork.CommitAsync(cancellationToken);
        return category;
    }
}