using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SocialSolutions.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialSolutions.Models
{
    public static class DatabasePreparation
    {
        public static void Preparate(IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                SeedDatabase(scope.ServiceProvider.GetRequiredService<ApplicationDbContext>());
            }
        }

        private static void SeedDatabase(ApplicationDbContext context)
        {
            if (context.Database.EnsureCreated())
                context.Database.Migrate();
        }
    }
}
