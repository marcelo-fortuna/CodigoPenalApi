using CodigoPenalApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodigoPenalApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<CriminalCode> CriminalCode { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "Admin",
                    Password = "Admin"
                }
            );
        }
    }
}
