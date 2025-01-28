using Finance.Application.Business.Categories.Commands.CreateCategory;
using Finance.Application.Common.Errors;
using Finance.Application.Common.Interface.Repository;
using Finance.Domain.Categories;

namespace Finance.Application.Tests.Categories.Handlers;

public class CreateCategoryHandlerTest
{
    private readonly AutoMocker _mocker;
    private readonly CreateCategoryHandler _handler;

    public CreateCategoryHandlerTest()
    {
        _mocker = new AutoMocker();
        _handler = _mocker.CreateInstance<CreateCategoryHandler>();
    }

    [Trait("Validation", "Error")]
    [Fact(DisplayName = "It should return ParentNonexistent error when passing parent category to command that don't exists ")]
    public async Task Handle_ParentNonExistent_ShouldReturnErrorParentNonExistent()
    {
        var command = new AutoFaker<CreateCategoryCommand>().Generate();
        _mocker.GetMock<ICategoryRepository>()
            .Setup(s => s.ExistsAsync(It.IsAny<Expression<Func<Category, bool>>>(), default))
            .ReturnsAsync(false);
        
        var result = await _handler.Handle(command, CancellationToken.None);
        
        Assert.True(result.HasErrors);
        Assert.Collection(result.Errors, error => Assert.Equal( Error.Category.ParentNonExistent, error));
        Assert.Single(result.Errors);
        _mocker.GetMock<ICategoryRepository>().Verify(v => v.ExistsAsync(It.IsAny<Expression<Func<Category, bool>>>(), CancellationToken.None), Times.Once);
        _mocker.GetMock<ICategoryRepository>().Verify(v => v.CommitAsync(CancellationToken.None), Times.Never);
    }
    
    [Trait("Validation", "Error")]
    [Fact(DisplayName = "It should return CategoryWithSameDescription error when passing an description that already exists")]
    public async Task Handle_SameDescription_ShouldReturnErrorCategoryWithSameDescription()
    {
        var command = new AutoFaker<CreateCategoryCommand>().Generate();
        _mocker.GetMock<ICategoryRepository>()
            .Setup(s => s.ExistsAsync(w => w.Id.Equals(command.ParentId!.Value), CancellationToken.None))
            .ReturnsAsync(true);
        
        _mocker.GetMock<ICategoryRepository>()
            .Setup(w => w.ExistsAsync(w => w.Description.Trim().Equals(command.Description.Trim()), CancellationToken.None))
            .ReturnsAsync(true);
        
        var result = await _handler.Handle(command, CancellationToken.None);
        
        Assert.True(result.HasErrors);
        Assert.Collection(result.Errors, error => Assert.Equal(Error.Category.CategoryWithSameDescription, error));
        Assert.Single(result.Errors);
        _mocker.GetMock<ICategoryRepository>().Verify(v => v.CommitAsync(CancellationToken.None), Times.Never);
    }
    
    [Trait("Creation", "Success")]
    [Fact(DisplayName = "It should create category")]
    public async Task Handle_ValidCommand_ShouldCreateCategory()
    {
        var command = new AutoFaker<CreateCategoryCommand>().Generate();
        _mocker.GetMock<ICategoryRepository>()
            .Setup(s => s.ExistsAsync(w => w.Id.Equals(command.ParentId!.Value), CancellationToken.None))
            .ReturnsAsync(true);
        
        _mocker.GetMock<ICategoryRepository>()
            .Setup(w => w.ExistsAsync(w => w.Description.Trim().Equals(command.Description.Trim()), CancellationToken.None))
            .ReturnsAsync(false);
        
        var result = await _handler.Handle(command, CancellationToken.None);
        
        Assert.False(result.HasErrors);
        Assert.Empty(result.Errors);
        _mocker.GetMock<ICategoryRepository>().Verify(v => v.CreateAsync(It.IsAny<Category>(),CancellationToken.None), Times.Once);
        _mocker.GetMock<ICategoryRepository>().Verify(v => v.CommitAsync(CancellationToken.None), Times.Once);
    }
}