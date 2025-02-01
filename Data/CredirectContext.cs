using credirect_api.Models;
using Microsoft.EntityFrameworkCore;

namespace credirect_api.Data
{
    public class CredirectContext : DbContext
    {
        public CredirectContext(DbContextOptions<CredirectContext> options) : base(options) { }

        public DbSet<StudentDetail> StudentDetail { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ClientIdentity> ClientIdentity { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<ResidencyStatus> ResidencyStatus { get; set; }
        public DbSet<BusinessActivity> BusinessActivity { get; set; }
        public DbSet<ClientTitle> ClientTitle { get; set; }
        public DbSet<ClientCountry> ClientCountry { get; set; }
        public DbSet<ClientRole> ClientRole { get; set; }
        public DbSet<ClientOrigin> ClientOrigin { get; set; }

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
                .HasOne(c => c.Role)
                .WithOne()
                .HasForeignKey<Client>(c => c.RoleID);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.Origin)
                .WithOne()
                .HasForeignKey<Client>(c => c.OriginID);

            //modelBuilder.Entity<ClientIdentity>()
            //    .HasKey(ci => ci.IdentityID); 

            //modelBuilder.Entity<ManagerInformation>()
            //    .HasKey(m => m.ManagerID);

            // Add other relationships as needed.
        }
    }
}