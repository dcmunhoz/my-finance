using Api.Core.Responses.Error;
using Finance.Api.Requests.Category;
using Finance.Api.Responses.Category;
using Finance.Application.Commands.CategoryAggregate.CreateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{ 
    private readonly IMediator _mediator;
    
    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CategoryCreatedResponse), 201)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [ProducesResponseType(typeof(ErrorResponse), 500)]
    public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryRequest request, CancellationToken token = default)
    {
        var command = new CreateCategoryCommand(request.Name, request.Color, request.ParentId);

        var category = await _mediator.Send(command, token);
        if (category is null)
            return new BadRequestResult();

        return Created($"/categories/{category.Id}", new CategoryCreatedResponse(category.Id));
    }
}