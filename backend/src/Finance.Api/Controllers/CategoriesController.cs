using Common.Api.ApiBaseController;
using Finance.Api.Services;
using Finance.Application.Business.Categories.Commands.CreateCategory;
using Finance.Application.Common.Interface.Queries;
using Finance.Contracts.Categories.Requests;
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
    private readonly ICategoryQuery _categoryQuery;
    
    public CategoriesController(IMediator mediator, TokenService tokenService, ICategoryQuery categoryQuery)
    {
        _mediator = mediator;
        _tokenService = tokenService;
        _categoryQuery = categoryQuery;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken token = default)
        => Ok(await _categoryQuery.GetByIdAsync(id, token));
}
