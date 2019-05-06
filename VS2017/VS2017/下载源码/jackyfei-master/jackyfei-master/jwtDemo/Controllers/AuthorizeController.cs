using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace jwtDemo.Controllers
{ 
    [Route("api/[controller]")]
    public class AuthorizeController : ControllerBase
    {
        private JwtSetting _jwtSetting;
        public AuthorizeController(IOptions<JwtSetting> jwtSetting)
        {
            _jwtSetting = jwtSetting.Value;
        }


        // GET api/values
        [HttpPost]
        public IActionResult Get(LoginModule login)
        {
            if(ModelState.IsValid)
            {
                if(!(login.UserName=="jackyfei"&&login.PassWord == "123qwe"))
                {
                    return BadRequest();
                }

                var claims =new Claim[]{
                    new Claim(ClaimTypes.Name,"jackyfei"),
                    //new Claim(ClaimTypes.Role,"admin"),
                    new Claim("Admin","true"),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.SecretKey));
                var credentials =new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

                var token =new JwtSecurityToken(
                    _jwtSetting.Issuer,
                    _jwtSetting.Audience,
                    claims,
                    null,
                    DateTime.Now.AddMinutes(120),
                    credentials
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

            }

            return BadRequest();

        }

    }

}