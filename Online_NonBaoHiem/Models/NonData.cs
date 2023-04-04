using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Online_NonBaoHiem.Models
{
    public partial class NonData : DbContext
    {
        public NonData()
            : base("name=NonData1")
        {
        }

        public virtual DbSet<AdminAccount> AdminAccounts { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillInfo> BillInfoes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Helmet> Helmets { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .HasMany(e => e.BillInfoes)
                .WithRequired(e => e.Bill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bill>()
                .HasMany(e => e.Feedbacks)
                .WithRequired(e => e.Bill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BillInfo>()
                .Property(e => e.ToltalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Helmets)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerAccount>()
                .Property(e => e.CustomerEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Helmet>()
                .Property(e => e.Thumbnail)
                .IsUnicode(false);

            modelBuilder.Entity<Helmet>()
                .HasMany(e => e.BillInfoes)
                .WithRequired(e => e.Helmet)
                .WillCascadeOnDelete(false);
        }
    }
}
