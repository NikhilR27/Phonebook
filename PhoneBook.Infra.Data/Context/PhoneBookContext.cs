using System;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain;

namespace PhoneBook.Infra.Data.Context
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Phonebook> PhoneBook { get; set; }

        public PhoneBookContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite(@"Data Source=/tmp/phonebook.db");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //#region Required
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Entry>(entity =>
        //    {
        //        entity.Property(b => b.Name)
        //              .IsRequired();
        //    });

        //    modelBuilder.Entity<Phonebook>(entity =>
        //    {
        //        entity.Property(b => b.Name)
        //              .IsRequired();

        //        entity.Property(p => p.Entries);

        //    });
        //}
        //#endregion
    }
}
