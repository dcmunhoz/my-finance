using Api.Core.Responses.Error;
using Finance.Application.Business.CategoryAggregate.Commands.CreateCategory;
using Finance.Application.Queries;
using Finance.Contracts.Requests.Category;
using Finance.Contracts.Responses.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{ 
    private readonly IMediator _mediator;
    private readonly ICategoryQuery _categoryQuery;

    public CategoriesController(IMediator mediator, ICategoryQuery categoryQuery)
    {
        _mediator = mediator;
        _categoryQuery = categoryQuery;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CategoryCreatedResponse), 201)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [ProducesResponseType(typeof(ErrorResponse), 500)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryRequest request, CancellationToken token = default)
    {
        var command = new CreateCategoryCommand(request.Name, request.Color, request.ParentId);

        var category = await _mediator.Send(command, token);
        if (category is null)
            return new BadRequestResult();

        return Created($"/categories/{category.Id}", new CategoryCreatedResponse(category.Id));
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        var result = await _categoryQuery.GetByIdAsync(Id);
        if (result is null)
            return NotFound();

        return Ok(result);
    }
}