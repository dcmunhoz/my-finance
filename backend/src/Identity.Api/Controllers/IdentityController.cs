using Common.Api.Response;
using Identity.Api.Data.Context;
using Identity.Api.Models;
using Identity.Api.Requests;
using Identity.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class IdentityController : ControllerBase
{
    private readonly IdentityDbContext _context;
    private readonly HashService _hashService;
    
    public IdentityController(IdentityDbContext context, HashService hashService)
    {
        _context = context;
        _hashService = hashService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        RegisterUserRequestValidation validation = new();
        var result = await validation.ValidateAsync(request, cancellationToken);

        if (!result.IsValid)
        {
            var response = new ErrorResponse
            {
                Id = nameof(RegisterUserAsync),
                Title = "Validation errors occurred",
                Details =  result.Errors.Select(s => new ErrorDetailsResponse
                {
                    Title = s.PropertyName,
                    Message = s.ErrorMessage
                })
            };

            return BadRequest(response);
        }

        if (await _context.Users.AnyAsync(w => w.Email.Trim().Equals(request.Email.Trim()), cancellationToken))
            return BadRequest(new ErrorResponse
            {
                Id = this.GetType().FullName ?? "",
                Title = "E-mail already exists",
                Message = "This e-mail is already registered. If you forget your password try to recovery."
            });
        
        User user = new(request.Name, request.Email, _hashService.GetStringHash(request.Password));
        
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Created("/api/auth/login", user.Id);
    }
}