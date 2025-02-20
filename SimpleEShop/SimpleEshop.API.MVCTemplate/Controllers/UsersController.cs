using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using SimpleEshop.API.MVCTemplate.Models;
using SimpleEshop.Application.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace SimpleEshop.API.MVCTemplate.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(UserLoginViewModel userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = userService.ValidateUser(userLogin.UserName, userLogin.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key-for-jwt-token@345"));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.FullName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)

            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "server",
                audience: "client",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials

                );

            return Ok(new {token = new JwtSecurityTokenHandler().WriteToken(token)});


        }
    }
}
