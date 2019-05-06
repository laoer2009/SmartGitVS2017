using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace jwtDemo
{
    public class MyValidateToken : ISecurityTokenValidator
    {
        public bool CanValidateToken => true;

        public int MaximumTokenSizeInBytes { get; set; }

        public bool CanReadToken(string securityToken)
        {
             return true;
        }

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
             validatedToken=null;
            //判断token是否正确
            if(securityToken!="myTokenSecret")
            return null;

            //给Identity赋值
            var identity=new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim("name","jackyfei"));
            identity.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType,"admin"));

            var principle=new ClaimsPrincipal(identity);
            return principle;

            // validatedToken = null;
            // var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);

            // if(securityToken == "myTokenSecret")
            // {
            //     identity.AddClaim(new Claim("name","jackyfei"));
            //     identity.AddClaim(new Claim("SuperAdminOnly","true"));
            //     identity.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType,"user"));
            //     //identity.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType,"admin"));
            // }

            // var principal = new ClaimsPrincipal(identity);

            // return principal;

        }
    }
}