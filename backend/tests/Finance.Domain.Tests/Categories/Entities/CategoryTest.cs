using Finance.Domain.Aggregates.Categories;
using Finance.Domain.Common.Enums;

namespace Finance.Domain.Tests.Categories.Entities;

public class CategoryTest
{
    [Fact(DisplayName = "It should create Category object with success")]
    public void Category_Valid_ShuldCreateObject()
    {
        Category category = new(MovementType.Incoming, "Test", "#FFF", Guid.Empty, Guid.Empty);
        
        Assert.NotNull(category);
    }
}