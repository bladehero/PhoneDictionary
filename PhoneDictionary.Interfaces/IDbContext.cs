using Microsoft.EntityFrameworkCore;
using PhoneDictionary.Data.Models;

namespace PhoneDictionary.Interfaces
{
    public interface IDbContext
    {
        public DbSet<User> Users { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
    }
}