using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialSolutions.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using SocialSolutions.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SocialSolutions
{
    public class Startup
    {
        IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(config =>
            {
                config.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                });        
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(_config.GetConnectionString("default")));

            services.AddTransient<IProfileRepository>(impl =>
               new ProfileRepository(impl.GetRequiredService<ApplicationDbContext>()));

            services.AddTransient<IRoleRepository>(impl =>
                new RoleRepository(impl.GetRequiredService<ApplicationDbContext>()));

            services.AddTransient<IAccountRepository>(impl =>
                new AccountRepository(impl.GetRequiredService<ApplicationDbContext>()));

            services.AddAuthentication(config =>
            {
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
                {
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = _config["Jwt:Issuer"],
                        ValidAudience = _config["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]))
                    };
                });

            services.AddAuthorization(config =>
            {
                config.AddPolicy("userPolicy", userPolicy =>
                {
                    userPolicy.RequireRole("User");
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(config =>
            {
                config.AllowAnyOrigin();
                config.AllowAnyMethod();
                config.AllowAnyHeader();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller}/{action}/{param?}");
            });
        }
    }
}
