using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MvcProblems;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IOptions<JwtSettings> _jwtOptions;

    public AuthController(IOptions<JwtSettings> jwtOptions)
    {
        _jwtOptions = jwtOptions;
    }
    
    [HttpPost]
    public IActionResult Index()
    {
        var jwtSettings = _jwtOptions.Value;

        var tokenHandler = new JwtSecurityTokenHandler();
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = jwtSettings.Audience,
            Issuer = jwtSettings.Issuer,
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.Add(jwtSettings.ExpiresIn),
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "test-user"),
                new Claim(ClaimTypes.Role, "Standard")
            }),
            SigningCredentials = new SigningCredentials(jwtSettings.GetSigningKey(), SecurityAlgorithms.HmacSha256Signature)
        };

        var jwt = tokenHandler.CreateEncodedJwt(tokenDescriptor);

        return Ok(jwt);
    }
}