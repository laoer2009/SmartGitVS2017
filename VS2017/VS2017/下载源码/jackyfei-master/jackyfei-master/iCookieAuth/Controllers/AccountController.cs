using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iCookieAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace iCookieAuth.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
              var claims=new List<Claim>(){
                new Claim(ClaimTypes.Name,"wangyuting"),
                new Claim(ClaimTypes.Role,"admin")

            };
            //必须要加CookieAuthenticationDefaults.AuthenticationScheme，不然无法解析
            var claimsIdentity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity));
            return Ok();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }

    
    }
}
