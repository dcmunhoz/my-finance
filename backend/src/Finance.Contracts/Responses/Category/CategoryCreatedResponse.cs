namespace Finance.Contracts.Responses.Category;

public record CategoryCreatedResponse(Guid CategoryId)
{
    public static CategoryCreatedResponse MapFrom(Domain.Aggregates.Category category)
    {
        return new CategoryCreatedResponse(category.Id);
    }
}
