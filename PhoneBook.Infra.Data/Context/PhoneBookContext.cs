using System;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain;

namespace PhoneBook.Infra.Data.Context
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext()
        {
        }

        public PhoneBookContext(DbContextOptions<PhoneBookContext> options)
          : base((DbContextOptions)options)
        {
        }

        public virtual DbSet<Entry> Entries { get; set; }

        public virtual DbSet<Phonebook> Phonebooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", (object)"en_US.utf8");
            modelBuilder.HasCollation("my_collation", "und-u-ks-level2", "icu", false); ;

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.ToTable("entry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("number");

                entity.Property(e => e.PhonebookId).HasColumnName("phonebook_id");
            });

            modelBuilder.Entity<Phonebook>(entity =>
            {
                entity.ToTable("phonebook");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });
        }
    }
}
