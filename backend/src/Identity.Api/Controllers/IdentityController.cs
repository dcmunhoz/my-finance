using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Common.Api.Response;
using Identity.Api.Data.Context;
using Identity.Api.Models;
using Identity.Api.Requests;
using Identity.Api.Responses;
using Identity.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class IdentityController : ControllerBase
{
    private readonly IdentityDbContext _context;
    private readonly HashService _hashService;
    private readonly IConfiguration _configuration;
    
    public IdentityController(IdentityDbContext context, HashService hashService, IConfiguration configuration)
    {
        _context = context;
        _hashService = hashService;
        _configuration = configuration;
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
                Title = "Ocorreram erros de validação",
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
                Title = "Este e-mail já existe",
                Message = "Este e-mail já esta registrado. Se você esqueceu sua senha tente recupera-la."
            });
        
        User user = new(request.Name, request.Email, _hashService.GetStringHash(request.Password));
        
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Created("/api/auth/login", user.Id);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(w => w.Email.Trim().Equals(request.Email.Trim()) &&
                                                                      w.Password.Trim().Equals(_hashService.GetStringHash(request.Password)), 
                                                            cancellationToken);

        if (user is null)
            return BadRequest(new ErrorResponse
            {
                Title = "Falha ao autenticar",
                Message = "Usuário ou senha incorretos, tente novamente."
            });
        
        var secret = _configuration.GetSection("JWTAuthentication:Secret").Value ?? "";
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            ]),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Ok(new LoginResponse(tokenHandler.WriteToken(token), user.Name, user.Email ));
    }
}