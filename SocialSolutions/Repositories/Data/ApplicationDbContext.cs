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

            builder.Entity<User>(usr =>
            {
                usr.HasMany(prop => prop.CreatedEvents)
                    .WithOne(prop => prop.Creator)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasForeignKey("creator_id")
                    .IsRequired(true);

                usr.HasMany(prop => prop.ModeratedEvents)
                    .WithOne(prop => prop.Moderator)
                    .HasForeignKey("moderator_id")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(false);

                usr.HasMany(prop => prop.OwnCommunities)
                    .WithOne(prop => prop.Owner)
                    .HasForeignKey("owner_id")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(true);

                usr.HasMany(prop => prop.Albums)
                    .WithOne(prop => prop.Owner)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasForeignKey("owner_id")
                    .IsRequired(true);
            });

            builder.Entity<Community>()
                .HasOne<User>(prop => prop.Owner)
                .WithMany(prop => prop.OwnCommunities)
                .HasForeignKey("owner_id")
                .OnDelete(DeleteBehavior.NoAction);

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
