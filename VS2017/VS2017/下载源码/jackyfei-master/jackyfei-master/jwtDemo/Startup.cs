using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace jwtDemo
{
   public class Startup
    {
        public IConfiguration _configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //配置授权策略必须为Admin
            services.AddAuthorization(Options=>{
                Options.AddPolicy("Admin",policy=>policy.RequireClaim("Admin"));

            });

            services.Configure<JwtSetting>(_configuration.GetSection("JwtSetting"));

            var jwtSetting= new JwtSetting();
            _configuration.Bind("JwtSetting",jwtSetting);

            //JWT相关参数的配置
            services.AddAuthentication(options=>{
                options.DefaultAuthenticateScheme =JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o=>{
                o.TokenValidationParameters = new TokenValidationParameters{
                    ValidIssuer = jwtSetting.Issuer,
                    ValidAudience=jwtSetting.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SecretKey))
                };

                //清除默认验证
                // o.SecurityTokenValidators.Clear();
                // //自定义ValidateToken
                // o.SecurityTokenValidators.Add(new MyValidateToken());
                
                // //自定义Header参数
                // o.Events =new JwtBearerEvents(){
                //     OnMessageReceived = context =>{
                //         var token = context.Request.Headers["token"];
                //         context.Token =token.FirstOrDefault();
                //         return Task.CompletedTask;
                //     }
                // };
            });

            //配置授权策略必须为Admin
            services.AddAuthorization(Options=>{
                Options.AddPolicy("Admin",policy=>policy.RequireClaim("Admin"));

            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
