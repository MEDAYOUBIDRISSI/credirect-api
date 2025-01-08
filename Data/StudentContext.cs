using credirect_api.Models;
using Microsoft.EntityFrameworkCore;

namespace credirect_api.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public DbSet<StudentDetail> StudentDetail { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ClientIdentity> ClientIdentitie { get; set; }
        public DbSet<MaritalStatus> MaritalStatuse { get; set; }
        public DbSet<ResidencyStatus> ResidencyStatuse { get; set; }
        public DbSet<BusinessActivity> BusinessActivitie { get; set; }
        public DbSet<ClientTitle> ClientTitle { get; set; }
        public DbSet<ClientCountry> ClientCountrie { get; set; }
        public DbSet<ManagerInformation> ManagerInformation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasOne(c => c.ClientTitle)
                .WithMany()
                .HasForeignKey(c => c.ClientTitleID);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.ClientIdentity)
                .WithMany()
                .HasForeignKey(c => c.IdentityID);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryID);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.ResidenceCountry)
                .WithMany()
                .HasForeignKey(c => c.ResidenceCountryID);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.Manager)
                .WithOne()
                .HasForeignKey<Client>(c => c.ManagerID);

            modelBuilder.Entity<ClientIdentity>()
                .HasKey(ci => ci.IdentityID);

            modelBuilder.Entity<ManagerInformation>()
                .HasKey(m => m.ManagerID); // Explicitly set the primary key

            // Add other relationships as needed.
        }
    }
}