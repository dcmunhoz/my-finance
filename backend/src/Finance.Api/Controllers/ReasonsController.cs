using BaseAuthentication.Services;
using Common.Api.ApiBaseController;
using Finance.Application.Business.Reasons.Commands.CreateReason;
using Finance.Contracts.Reasons.Requests;
using Finance.Domain.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Api.Controllers;

[ApiController]
[Authorize]
[Route("/api/reasons")]
public class ReasonsController : ApiBaseController
{
    private readonly ITokenService _tokenService;
    private readonly IMediator _mediator;
    
    public ReasonsController(ITokenService tokenService, IMediator mediator)
    {
        _tokenService = tokenService;
        _mediator = mediator;
    }
    
    public async Task<IActionResult> Create([FromBody] CreateReasonRequest request)
    {
        CreateReasonCommand command = new()
        {
            Type = (MovementType)request.Type,
            Description = request.Description,
            Color = request.Color,
            UserId = _tokenService.GetUserId()
        };
        
        return CreateResponseOnPost(await _mediator.Send(command), "/");
    }
}