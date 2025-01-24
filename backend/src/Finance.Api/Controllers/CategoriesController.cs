using Finance.Api.Contracts.Categories.Requests;
using Finance.Application.Business.Categories.Commands.CreateCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Api.Controllers;

[ApiController]
[Route("api/categories")]
[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request, CancellationToken token = default)
    {
        CreateCategoryCommand command = new()
        {
            ParentId = request.ParentId,
            Color = request.Color,
            Description = request.Description,
            UserId = Guid.Empty
        } ;

        var result = await _mediator.Send(command, token);
        
        return Created("/", result);
    }
}
