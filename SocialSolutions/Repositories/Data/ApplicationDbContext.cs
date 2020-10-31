using Microsoft.EntityFrameworkCore;
using SocialSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialSolutions.Repositories.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public ApplicationDbContext()
        { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        { }

        
    }
}
