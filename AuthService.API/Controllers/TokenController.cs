using AuthService.Application.DTOs;
using AuthService.Domain.Account;
using AuthService.Infra.Data.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AuthenticateService _authenticateService;

        public TokenController(IAuthenticate authentication, IConfiguration configuration, UserManager<ApplicationUser> userManager, AuthenticateService authenticateService)
        {
            _authentication = authentication ?? throw new ArgumentNullException(nameof(authentication));
            _configuration = configuration;
            _userManager = userManager;
            _authenticateService = authenticateService;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] LoginCreateDTO userInfo)
        {
            var result = await _authentication.RegisterUser(userInfo.UserName, userInfo.PhoneNumber, userInfo.Email, userInfo.Password);

            if (result)
            {
                return Ok($"User {userInfo.Email} was create successfully");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserTokenDTO>> Login([FromBody] LoginDTO userInfo)
        {
            var result = await _authentication.Authenticate(userInfo.Email, userInfo.Password);

            if (result)
            {
                return await GenerateToken(userInfo);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }

        private async Task<UserTokenDTO> GenerateToken(LoginDTO userInfo)
        {
            var user = await _userManager.FindByEmailAsync(userInfo.Email);
            var userRoles = await _userManager.GetRolesAsync(user);

            //declaração do usuário
            var claims = new List<Claim>
            {
                new Claim("email", user.Email ?? string.Empty),
                new Claim("userName", user?.UserName ?? string.Empty),
                new Claim("phone", user?.PhoneNumber ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in userRoles)
            {
                claims.Add(new Claim("role", role));
            }

            //gerar chave privada para assinar o token
            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            //gerar a assinatura digital
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            //definir o tempo de expiração
            var expiration = DateTime.UtcNow.AddMinutes(100);

            //gerar o token
            JwtSecurityToken token = new JwtSecurityToken(
                //emissor
                issuer: _configuration["Jwt:Issuer"],
                //audiencia
                audience: _configuration["Jwt:Audience"],
                //claims
                claims: claims,
                //data de expiração
                expires: expiration,
                //assinatura digital
                signingCredentials: credentials
             );

            return new UserTokenDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
