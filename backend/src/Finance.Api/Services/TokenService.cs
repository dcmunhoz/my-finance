using System.Security.Claims;

namespace Finance.Api.Services;

public class TokenService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public TokenService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public Guid GetUserId()
    {
        return Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}