using Microsoft.EntityFrameworkCore;
using PhoneDictionary.Data.Models;
using PhoneDictionary.Interfaces;

namespace PhoneDictionary.Data.Infrastructure
{
    public sealed class AppDbContext : DbContext, IDbContext
    {
        private readonly ISeedFaker _seedFaker;

        #region Tables

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        public AppDbContext(DbContextOptions<AppDbContext> options, ISeedFaker seedFaker) : base(options)
        {
            _seedFaker = seedFaker;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasOne(x => x.ContactInfo)
                .WithOne(x => x.Contact)
                .HasForeignKey<ContactInfo>(x => x.ContactId);

            base.OnModelCreating(modelBuilder);

            _seedFaker.Prepare();

            modelBuilder.Entity<Moderator>().HasData(_seedFaker.Moderators);
            modelBuilder.Entity<User>().HasData(_seedFaker.Users);
            modelBuilder.Entity<Tag>().HasData(_seedFaker.Tags);
            modelBuilder.Entity<Contact>().HasData(_seedFaker.Contacts);
            modelBuilder.Entity<ContactInfo>().HasData(_seedFaker.ContactInfos);
        }
    }
}