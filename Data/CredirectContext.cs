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
        public DbSet<ClientLegalForm> ClientLegalForm { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<ResidencyStatus> ResidencyStatus { get; set; }
        public DbSet<BusinessActivity> BusinessActivity { get; set; }
        public DbSet<ClientTitle> ClientTitle { get; set; }
        public DbSet<ClientCountry> ClientCountry { get; set; }
        public DbSet<ClientRole> ClientRole { get; set; }
        public DbSet<ClientOrigin> ClientOrigin { get; set; }
        public DbSet<ClientManager> ClientManager { get; set; }
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
                .HasOne(c => c.ClientLegalForm)
                .WithMany()
                .HasForeignKey(c => c.LegalFormID);

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

            // Configure ClientManager relationships
            modelBuilder.Entity<ClientManager>()
                .HasKey(cm => cm.ClientManagerID);

            modelBuilder.Entity<ClientManager>()
                .HasOne(cm => cm.Client)
                .WithMany(c => c.ClientManagers)
                .HasForeignKey(cm => cm.ClientID);

            modelBuilder.Entity<ClientManager>()
                .HasOne(cm => cm.ManagerInformation)
                .WithMany(m => m.ClientManagers)
                .HasForeignKey(cm => cm.ManagerID);

            // Configure ManagerInformation relationships
            modelBuilder.Entity<ManagerInformation>()
                .HasOne(m => m.ManagerTitle)
                .WithMany()
                .HasForeignKey(m => m.ManagerTitleID);

            modelBuilder.Entity<ManagerInformation>()
                .HasOne(m => m.Identity)
                .WithMany()
                .HasForeignKey(m => m.Id_Identity);

            modelBuilder.Entity<ManagerInformation>()
                .HasOne(m => m.ManagerCountry)
                .WithMany()
                .HasForeignKey(m => m.ManagerCountryID);

            modelBuilder.Entity<ManagerInformation>()
                .HasOne(m => m.ManagerResidenceCountry)
                .WithMany()
                .HasForeignKey(m => m.ManagerResidenceCountryID);

            modelBuilder.Entity<ManagerInformation>()
                .HasOne(m => m.ManagerMaritalStatus)
                .WithMany()
                .HasForeignKey(m => m.Id_ManagerMaritalStatus);

            modelBuilder.Entity<ClientIdentity>()
                .HasKey(c => c.IdentityID);

            modelBuilder.Entity<ClientLegalForm>()
                .HasKey(c => c.LegalFormID);

            modelBuilder.Entity<ClientOrigin>()
                .HasKey(c => c.OriginID);

            modelBuilder.Entity<ClientRole>()
                .HasKey(c => c.RoleID);

            modelBuilder.Entity<ManagerInformation>()
                .HasKey(m => m.ManagerID);

        }
    }
}