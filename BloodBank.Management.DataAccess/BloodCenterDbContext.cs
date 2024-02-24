using BloodBank.Management.Models.Entity;
using System.Data.Entity;

namespace BloodBank.Management.DataAccess
{
    public class BloodCenterContext : DbContext
    {
        public BloodCenterContext() : base("BloodCenterConnection")
        {

        }
        public DbSet<BloodGroup> BloodGroup { get; set; }
        public DbSet<Donation> Donation { get; set; }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Recipient> Recipient { get; set; }

        public DbSet<Test> Test { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Donor>()
            //    .HasRequired(c => c.BloodGroup)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Recipient>()
            //    .HasRequired(c => c.BloodGroup)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Recipient>()
            //    .HasRequired(c => c.Hospital)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Inventory>()
            //    .HasRequired(c => c.Donor)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Inventory>()
            //   .HasRequired(c => c.BloodGroup)
            //   .WithMany()
            //   .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Donation>()
            //  .HasRequired(c => c.Donor)
            //  .WithMany()
            //  .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Donation>()
            //   .HasRequired(c => c.Recipient)
            //   .WithMany()
            //   .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

    }
}
