using Common.Api.ApiBaseController;
using Finance.Api.Contracts.Categories.Requests;
using Finance.Api.Services;
using Finance.Application.Business.Categories.Commands.CreateCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Api.Controllers;

[ApiController]
[Route("api/categories")]
[Authorize]
public class CategoriesController : ApiBaseController
{
    private readonly IMediator _mediator;
    private readonly TokenService _tokenService;
    
    public CategoriesController(IMediator mediator, TokenService tokenService)
    {
        _mediator = mediator;
        _tokenService = tokenService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request, CancellationToken token = default)
    {
        CreateCategoryCommand command = new()
        {
            Type = request.Type,
            ParentId = request.ParentId,
            Color = request.Color,
            Description = request.Description,
            UserId = _tokenService.GetUserId()
        } ;

        var result = await _mediator.Send(command, token);

        return CreateResponseOnPost(result, "/");
    }
}
