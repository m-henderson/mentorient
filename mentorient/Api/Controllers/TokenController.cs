using mentorient.Api.ViewModels;
using mentorient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace mentorient.Api.Controllers
{
   [AllowAnonymous]
   [Route("api/[controller]")]
   public class TokenController : Controller
   {
      private readonly UserManager<ApplicationUser> _userManager;
      private readonly SignInManager<ApplicationUser> _signInManager;
      private readonly IConfiguration _config;

      public TokenController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          IConfiguration config)
      {
         _userManager = userManager;
         _signInManager = signInManager;
         _config = config;
      }

      [HttpPost]
      public async Task<IActionResult> GenerateToken([FromBody] TokenLoginViewModel model)
      {
         if (ModelState.IsValid)
         {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
               var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
               if (result.Succeeded)
               {
                  var claims = new[]
                  {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        }.Union(User.Claims);

                  var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                  var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                  var token = new JwtSecurityToken(
                      _config["Tokens:Issuer"],
                      _config["Tokens:Issuer"],
                      claims,
                      expires: DateTime.Now.AddDays(1),
                      signingCredentials: credentials);

                  return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
               }
            }
         }

         return BadRequest("Could not create token.");
      }
   }
}
