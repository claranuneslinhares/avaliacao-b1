using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace avaliacao_b1.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel login)
        {
            if (login.Username == "admin"
                && login.Password == "123456")
            {
                var token = GerarToken();

                return Ok(new { token });
            }

            return Unauthorized();
        }

        private string GerarToken()
        {
            var keyString = _config["Jwt:Key"] ?? throw new InvalidOperationException("Config 'Jwt:Key' não configurada.");
            var issuer = _config["Jwt:Issuer"] ?? throw new InvalidOperationException("Config 'Jwt:Issuer' não configurada.");
            var audience = _config["Jwt:Audience"] ?? throw new InvalidOperationException("Config 'Jwt:Audience' não configurada.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginModel
    {
        public required string Username { get; set; }

        public  required string Password { get; set; }
    }
}