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

        #region DB Credetionals

        private string DBServer;
        private string DBPassword;
        private string DBPort;
        private string DBUser;
        private string Database;

        #endregion

        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _env = env;

            //DBServer = _config["DBServer"] ?? "92.38.189.217";
            //DBPassword = _config["DBPassword"] ?? "123456";
            //DBPort = _config["DBPort"] ?? "1111";
            //DBUser = _config["DBUser"] ?? "root";
            //Database = _config["Database"] ?? "socialSolutions_db";
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

            services.AddDbContext<ApplicationDbContext>(config =>
                config.UseMySql("Server=my-sql-container; Port=1111; Username=root; Password=123456; Database=socialSolutions_db"));


            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IRoleStore<Role>>(
                impl => new ApplicationRoleStore(
                    impl.GetRequiredService<ApplicationDbContext>()));

            services.AddScoped<IUserStore<User>>(
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

            DatabasePreparation.Preparate(app);

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
