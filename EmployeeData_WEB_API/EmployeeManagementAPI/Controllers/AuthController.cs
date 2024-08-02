using EmployeeManagementAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
       public IActionResult Login([FromBody] Login user)
       {
            if(user == null)
            {
                return BadRequest("Inavalid USER");
            }
            if(user.UserName == "vishal@cap.com" && user.Password =="JWTAuthPass09")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JW:Secret"]));
                var signinCredentil = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOption = new JwtSecurityToken
                    (
                        issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"],
                        audience: ConfigurationManager.AppSetting["JWT:ValidAudience"],
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(6),
                        signingCredentials: signinCredentil
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);
                return Ok( new JWTTokenResponse
                {
                    Token = tokenString
                });
            }
            return Unauthorized();
       }
    }
}
