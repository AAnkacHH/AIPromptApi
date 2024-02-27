using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PromptAPI.Service;

namespace PromptAPI.Controllers.Auth;

[Route("api/[controller]")]
[ApiController]
public class TokenController(IConfiguration config, UserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LoginRequest loginRequest)
    {
        //your logic for login process
        //If login usrename and password are correct then proceed to generate token

        var user = await userService.FindUserByUsername(loginRequest.Email);

        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            // Add more claims here as needed
        };
        
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var sectoken = new JwtSecurityToken(config["Jwt:Issuer"],
            config["Jwt:Issuer"],
            null,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

        var token =  new JwtSecurityTokenHandler().WriteToken(sectoken);

        return Ok(token);
    }
}
