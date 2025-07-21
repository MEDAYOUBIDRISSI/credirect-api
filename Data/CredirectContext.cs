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

        // New DbSet properties
        public DbSet<InfoProfessional> InfoProfessionals { get; set; }
        public DbSet<AgencyBank> AgencyBank { get; set; }
        public DbSet<InfosBank> InfosBank { get; set; }
        public DbSet<NatureCommitment> NatureCommitments { get; set; }
        public DbSet<BankCommitmentsCharges> BankCommitmentsCharges { get; set; }
        public DbSet<CreditType> CreditType { get; set; }
        public DbSet<Credit> Credit { get; set; }
        public DbSet<LignCreditClient> LignCreditClient { get; set; }
        public DbSet<ObjectCredit> ObjectCredit { get; set; }
        public DbSet<NatureProperty> NatureProperty { get; set; }
        public DbSet<AssignmentProperty> AssignmentProperty { get; set; }
        public DbSet<UseProperty> UseProperty { get; set; }
        public DbSet<ConditionProperty> ConditionProperty { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<LignCreditProperty> LignCreditProperty { get; set; }

        public DbSet<ClientLegalForm> ClientLegalForm { get; set; }
        public DbSet<ClientManager> ClientManager { get; set; }
        public DbSet<ManagerInformation> ManagerInformation { get; set; }
        public DbSet<CreditDepot> CreditDepot { get; set; }
        public DbSet<CreditStatus> CreditStatus { get; set; }
        public DbSet<Pensionnaire> Pensionnaire { get; set; }
        public DbSet<GarantieCredit> GarantieCredit { get; set; }
        public DbSet<DepotStatus> DepotStatus { get; set; }
        public DbSet<CreditRemark> CreditRemark { get; set; }
        public DbSet<UserBO> UserBO { get; set; }
        public DbSet<RoleBO> RoleBO { get; set; }
        public DbSet<UserBORoleBO> UserBORoleBO { get; set; }

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

            modelBuilder.Entity<Client>()
                .HasMany(c => c.ClientManagers)
                .WithOne(cm => cm.Client)
                .HasForeignKey(cm => cm.ClientID);

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
                .HasKey(ci => ci.IdentityID);

            modelBuilder.Entity<ClientLegalForm>()
                .HasKey(c => c.LegalFormID);

            modelBuilder.Entity<ClientOrigin>()
                .HasKey(m => m.OriginID);

            modelBuilder.Entity<ClientRole>()
               .HasKey(m => m.RoleID);

            modelBuilder.Entity<ManagerInformation>()
               .HasKey(m => m.ManagerID);

            modelBuilder.Entity<CreditType>()
               .HasKey(m => m.TypeID);

            modelBuilder.Entity<InfosBank>()
               .HasKey(m => m.InfoBankID);

            // New relationships (if applicable)
            modelBuilder.Entity<InfoProfessional>()
                .HasOne(p => p.Client)
                .WithMany()
                .HasForeignKey(p => p.ClientID);

            modelBuilder.Entity<InfosBank>()
                .HasOne(b => b.Client)
                .WithMany()
                .HasForeignKey(b => b.ClientID);

            modelBuilder.Entity<InfosBank>()
                .HasOne(b => b.AgencyBank)
                .WithMany()
                .HasForeignKey(b => b.AgencyBankID);

            modelBuilder.Entity<BankCommitmentsCharges>()
                .HasKey(m => m.BankCommitmentChargeID);

            modelBuilder.Entity<BankCommitmentsCharges>()
                .HasOne(c => c.Client)
                .WithMany()
                .HasForeignKey(c => c.ClientID);

            modelBuilder.Entity<BankCommitmentsCharges>()
                .HasOne(c => c.AgencyBank)
                .WithMany()
                .HasForeignKey(c => c.AgencyBankID);

            modelBuilder.Entity<BankCommitmentsCharges>()
                .HasOne(c => c.NatureCommitment)
                .WithMany()
                .HasForeignKey(c => c.NatureCommitmentID);

            modelBuilder.Entity<Credit>()
                .HasOne(l => l.CreditType)
                .WithMany()
                .HasForeignKey(l => l.CreditTypeID);

            modelBuilder.Entity<LignCreditClient>()
                .HasOne(l => l.Client)
                .WithMany()
                .HasForeignKey(l => l.ClientID);

            modelBuilder.Entity<LignCreditClient>()
                .HasOne(l => l.Credit)
                .WithMany()
                .HasForeignKey(l => l.CreditID);

            modelBuilder.Entity<LignCreditProperty>()
                .HasOne(l => l.Credit)
                .WithMany()
                .HasForeignKey(l => l.CreditID);

            modelBuilder.Entity<LignCreditProperty>()
                .HasOne(l => l.ObjectCredit)
                .WithMany()
                .HasForeignKey(l => l.ObjectCreditID);

            modelBuilder.Entity<LignCreditProperty>()
                .HasOne(l => l.Property)
                .WithMany()
                .HasForeignKey(l => l.PropertyID);

            modelBuilder.Entity<Property>()
                .HasOne(p => p.NatureProperty)
                .WithMany()
                .HasForeignKey(p => p.NaturePropertyID);

            modelBuilder.Entity<Property>()
                .HasOne(p => p.AssignmentProperty)
                .WithMany()
                .HasForeignKey(p => p.AssignmentPropertyID);

            modelBuilder.Entity<Property>()
                .HasOne(p => p.UseProperty)
                .WithMany()
                .HasForeignKey(p => p.UsePropertyID);

            modelBuilder.Entity<Property>()
                .HasOne(p => p.ConditionProperty)
                .WithMany()
                .HasForeignKey(p => p.ConditionPropertyID);

            modelBuilder.Entity<Property>()
                .HasOne(p => p.Credit)
                .WithMany()
                .HasForeignKey(p => p.CreditID);

            modelBuilder.Entity<CreditDepot>()
                .HasOne(l => l.Credit)
                .WithMany()
                .HasForeignKey(l => l.id_credit);

            modelBuilder.Entity<CreditDepot>()
                .HasOne(l => l.AgencyBank)
                .WithMany()
                .HasForeignKey(l => l.id_agency_bank);

            modelBuilder.Entity<CreditStatus>()
                .HasOne(l => l.Credit)
                .WithMany()
                .HasForeignKey(l => l.id_credit);

            modelBuilder.Entity<CreditStatus>()
                .HasOne(l => l.CreditDepot)
                .WithMany()
                .HasForeignKey(l => l.id_depot);

            modelBuilder.Entity<CreditStatus>()
                .HasOne(l => l.bo_user)
                .WithMany()
                .HasForeignKey(l => l.user_bo_id);

            modelBuilder.Entity<Pensionnaire>()
                .HasOne(l => l.Client)
                .WithMany()
                .HasForeignKey(l => l.ClientID);

            modelBuilder.Entity<GarantieCredit>()
                .HasOne(l => l.Credit)
                .WithMany()
                .HasForeignKey(l => l.CreditID);

            modelBuilder.Entity<DepotStatus>()
                .HasOne(l => l.Credit)
                .WithMany()
                .HasForeignKey(l => l.CreditID);

            modelBuilder.Entity<DepotStatus>()
                .HasOne(l => l.CreditDepot)
                .WithMany()
                .HasForeignKey(l => l.CreditDepotID);

            modelBuilder.Entity<UserBORoleBO>()
                .HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId);

            modelBuilder.Entity<UserBORoleBO>()
                .HasOne(l => l.Role)
                .WithMany()
                .HasForeignKey(l => l.RoleId);

            modelBuilder.Entity<Client>()
                .HasOne(l => l.User_bo)
                .WithMany()
                .HasForeignKey(l => l.created_by);

            modelBuilder.Entity<Credit>()
                .HasOne(l => l.User_bo)
                .WithMany()
                .HasForeignKey(l => l.created_by);

            modelBuilder.Entity<CreditRemark>()
                .HasOne(l => l.Credit)
                .WithMany()
                .HasForeignKey(l => l.id_credit);

            modelBuilder.Entity<CreditRemark>()
                .HasOne(l => l.User_bo)
                .WithMany()
                .HasForeignKey(l => l.userID);


        }
    }
}