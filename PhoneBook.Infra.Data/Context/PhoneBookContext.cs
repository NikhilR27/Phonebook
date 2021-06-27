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
            modelBuilder.HasCollation("my_collation", "und-u-ks-level2", "icu", new bool?(false));
            modelBuilder.Entity<Entry>((Action<EntityTypeBuilder<Entry>>)(entity =>
            {
                entity.ToTable<Entry>("entry");
                entity.Property<int>((Expression<Func<Entry, int>>)(e => e.Id)).HasColumnName<int>("id");
                entity.Property<string>((Expression<Func<Entry, string>>)(e => e.Name)).IsRequired(true).HasMaxLength(50).HasColumnName<string>("name").UseCollation<string>("my_collation");
                entity.Property<string>((Expression<Func<Entry, string>>)(e => e.Number)).IsRequired(true).HasMaxLength(20).HasColumnName<string>("number");
                entity.Property<int>((Expression<Func<Entry, int>>)(e => e.PhonebookId)).HasColumnName<int>("phonebook_id");
                entity.HasOne<Phonebook>((Expression<Func<Entry, Phonebook>>)(d => d.Phonebook)).WithMany((Expression<Func<Phonebook, IEnumerable<Entry>>>)(p => p.Entries)).HasForeignKey((Expression<Func<Entry, object>>)(d => (object)d.PhonebookId)).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName<Phonebook, Entry>("fk_entry_phonebook");
            }));
            modelBuilder.Entity<Phonebook>((Action<EntityTypeBuilder<Phonebook>>)(entity =>
            {
                entity.ToTable<Phonebook>("phonebook");
                entity.Property<int>((Expression<Func<Phonebook, int>>)(e => e.Id)).HasColumnName<int>("id");
                entity.Property<string>((Expression<Func<Phonebook, string>>)(e => e.Name)).IsRequired(true).HasMaxLength(50).HasColumnName<string>("name");
            }));
        }
    }
}
