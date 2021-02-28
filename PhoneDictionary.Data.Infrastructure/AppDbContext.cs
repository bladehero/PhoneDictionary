using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PhoneDictionary.Data.Models;
using PhoneDictionary.Extensions;
using PhoneDictionary.Interfaces;

namespace PhoneDictionary.Data.Infrastructure
{
    public class AppDbContext : DbContext, IDbContext
    {
        #region Tables

        public DbSet<User> Users { get; set; }

        #endregion
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
#if DEBUG
            modelBuilder.Entity<User>().HasData(new List<User>
            {
                new User
                {
                    Id = 1,
                    Login = "Admin",
                    Password = "qwerty".ToMD5HashString()
                }
            });
#endif
            base.OnModelCreating(modelBuilder);
        }
    }
}