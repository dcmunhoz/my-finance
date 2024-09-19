using Finance.Api.Requests;
using Finance.Application.Business.Categories.CreateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{ 
    private readonly IMediator _mediator;
    
    
    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsyn([FromBody] CreateCategoryRequest request, CancellationToken token = default)
    {
        var command = new CreateCategoryCommand(request.Name, request.Color, request.ParentId);
        await _mediator.Send(command, token);
        return Ok("Ok");
    }
    
    
}