using Finance.Domain.Aggregates;

namespace Finance.Domain.Tests;
public class CategoryTest
{
    [Fact]
    public void Constructor_WithParent_ItShouldCreateValidObject()
    {
        var category = new Category(Guid.NewGuid(), "Category", "FFFFFF", Guid.NewGuid());

        Assert.NotNull(category);
    }

    [Fact]
    public void Constructor_WithoutParent_ItShouldCreateValidObject()
    {
        var category = new Category(Guid.NewGuid(), "Category", "FFFFFF");

        Assert.NotNull(category);
    }
}
