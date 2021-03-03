using Microsoft.EntityFrameworkCore;
using PhoneDictionary.Data.Models;

namespace PhoneDictionary.Interfaces
{
    public interface IDbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
    }
}