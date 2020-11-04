using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialSolutions.Repositories.Data
{
    public class ApplicationDbContext 
        : IdentityDbContext<User, Role, int,
                            IdentityUserClaim<int>, UsersRoles, 
                            IdentityUserLogin<int>, IdentityRoleClaim<int>,
                            IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Community>()
                .HasOne<User>()
                .WithMany(prop => prop.OwnCommunities)
                .HasForeignKey("owner_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Document>()
                .HasOne<User>()
                .WithMany(prop => prop.Documents)
                .HasForeignKey("owner_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UsersRoles>(ur =>
            {
                ur.HasKey(prop => prop.Id);

                ur.HasOne(prop => prop.Role)
                    .WithMany(prop => prop.UsersRoles)
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Restrict);

                ur.HasOne(prop => prop.User)
                    .WithMany(prop => prop.UsersRoles)
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
