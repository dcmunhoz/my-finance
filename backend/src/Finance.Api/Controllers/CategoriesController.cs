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
public class CategoriesController(IMediator mediator, ICategoryQuery categoryQuery) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(CategoryCreatedResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request, CancellationToken token = default)
    {
        var command = new CreateCategoryCommand(request.Name, request.Color, request.ParentId);

        var category = await mediator.Send(command, token);
        if (category is null)
            return new BadRequestResult();

        return CreatedAtAction(nameof(GetById), new { id = category.Id }, CategoryCreatedResponse.MapFrom(category));
    }

    [HttpGet("{id:guid}")]    
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await categoryQuery.GetByIdAsync(id, cancellationToken);
        if (result is null)
            return NotFound();

        return Ok(result);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        => Ok(await categoryQuery.GetAllAsync(cancellationToken));
    
}