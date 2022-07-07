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
                    UserName = "Administrador",
                    Password = "Admin1"
                }
            );
            modelBuilder.Entity<CriminalCode>().HasData(
                new CriminalCode
                {
                    Id = 1,
                    Name = "ATM",
                    Description = "Proibido fazer ATM em qualquer depêndencia de emprego legal.",
                    Penalty = 1,
                    PrisionTime = 30,
                    StatusId = 1,
                    CreateDate = DateTime.Today,
                    UpdateDate = DateTime.Today,
                    CreateUserId = 1,
                    UpdateUserId = 0
                }
            );
            modelBuilder.Entity<CriminalCode>().HasData(
                new CriminalCode
                {
                    Id = 2,
                    Name = "Tiro",
                    Description = "Proibido dar tiro em local de emprego legal.",
                    Penalty = 1,
                    PrisionTime = 40,
                    StatusId = 1,
                    CreateDate = DateTime.Today,
                    UpdateDate = DateTime.Today,
                    CreateUserId = 1,
                    UpdateUserId = 0
                }
            );
        }
    }
}
