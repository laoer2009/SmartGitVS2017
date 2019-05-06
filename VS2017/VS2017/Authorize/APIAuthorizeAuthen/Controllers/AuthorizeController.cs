using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using APIAuthorizeAuthen.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;

namespace APIAuthorizeAuthen.Controllers
{
    //JWT  使用说明  经典
    //https://www.cnblogs.com/chenwolong/p/Token.html
    [Route("api/[controller]")]
    public class AuthorizeController : Controller
    {
        private JwtSetting _jwtSetting;

        public AuthorizeController(IOptions<JwtSetting> jwtSetting)
        {
            _jwtSetting = jwtSetting.Value;
        }
        [HttpPost]
        public IActionResult Get(LoginModule login)
        {
            if (ModelState.IsValid)
            {
                if (!(login.UserName == "jackyfei" && login.PassWord == "123qwe"))
                {
                    return BadRequest();
                }

                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name,"jackyfei"),
                    new Claim(ClaimTypes.Role,"admin")
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.SecretKey));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                     _jwtSetting.Issuer,
                     _jwtSetting.Audience,
                     claims,
                     null,
                     DateTime.Now.AddMinutes(50),
                    credentials
                    );

                return Ok(new {token = new JwtSecurityTokenHandler().WriteToken(token)});
            }

            return BadRequest();
        }
    }
}