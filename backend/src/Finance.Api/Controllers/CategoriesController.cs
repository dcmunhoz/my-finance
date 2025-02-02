using BaseAuthentication.Services;
using Common.Api.ApiBaseController;
using Finance.Application.Business.Categories.Commands.CreateCategory;
using Finance.Application.Business.Categories.Commands.UpdateCategory;
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
    private readonly ITokenService _tokenService;
    private readonly ICategoryQuery _categoryQuery;
    
    public CategoriesController(IMediator mediator, ITokenService tokenService, ICategoryQuery categoryQuery)
    {
        _mediator = mediator;
        _tokenService = tokenService;
        _categoryQuery = categoryQuery;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken token = default)
        => CreateResponseOnGet(await _categoryQuery.GetByIdAsync(id, token));
    
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken token = default)
        => CreateResponseOnGet(await _categoryQuery.GetAllAsync(token));
    
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

        return CreateResponseOnPost(result, "/{id}");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody]UpdateCategoryRequest request, [FromRoute]Guid Id, CancellationToken token = default)
    {
        UpdateCategoryCommand command = new()
        {
            Id = Id,
            Description = request.Description,
            Color = request.Color,
            UserId = _tokenService.GetUserId()
        };
        
        var result = await _mediator.Send(command, token);

        return CreateResponseOnPut(result);
    }
}
