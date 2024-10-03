using Finance.Application.Repositories;
using Finance.Domain.Aggregates;
using MediatR;
using Notification;

namespace Finance.Application.Business.Categories.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly INotificationHandler _notificationHandler;
    
    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, INotificationHandler notificationHandler)
    {
        _categoryRepository = categoryRepository;
        _notificationHandler = notificationHandler;
    }
    
    public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(Guid.NewGuid(), request.Name, request.Color, request.ParentId);

        // _notificationHandler.WithTitle("Teste")
        //                     .WithDescription("Descrição XPTO")
        //                     .Raise();
        // return default;
        
        await _categoryRepository.CreateCategoryAsync(category, cancellationToken);
        return  await _categoryRepository.UnitOfWork.CommitAsync(cancellationToken);
    }
}