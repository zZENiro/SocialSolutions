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
using Microsoft.IdentityModel.JsonWebTokens;
using System.Net.Http;
using SocialSolutions.Models;
using Microsoft.AspNetCore.Identity;
using SocialSolutions.Repositories.Stores;
using System.Threading;

namespace SocialSolutions
{
    public class Startup
    {
        IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(config =>
            {
                config.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://ss.remonstro.ru", "https://ss.remonstro.ru");
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                });
            });

            services.AddTransient<CancellationTokenSource>();
            services.AddTransient<PasswordHasher<User>>();

            if (_env.IsDevelopment())
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(_config.GetConnectionString("debug_con")));
            }
            else if (_env.IsProduction())
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(_config.GetConnectionString("release_con")));
            }

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IRoleStore<Role>>(
                impl => new ApplicationRoleStore(
                    impl.GetRequiredService<ApplicationDbContext>()));

            services.AddTransient<IUserStore<User>>(
                impl => new ApplicationUserStore(
                    impl.GetRequiredService<ApplicationDbContext>()));

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
