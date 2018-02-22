namespace WebApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContextDB : DbContext
    {
        public ContextDB()
            : base("name=ContextDB")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<PersonAccount> PersonAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.account_number)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.outstanding_balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Transactions)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.account_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.id_number)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.person_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<PersonAccount>()
                .Property(e => e.id_number)
                .IsUnicode(false);

            modelBuilder.Entity<PersonAccount>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<PersonAccount>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<PersonAccount>()
                .Property(e => e.account_number)
                .IsUnicode(false);
        }
    }
}
