namespace credirect_api.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public bool? VIP { get; set; }
        public string? Matricule { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? ClientTitleID { get; set; }
        public ClientTitle? ClientTitle { get; set; }
        public string? Nationality { get; set; }
        public int? IdentityID { get; set; }
        public ClientIdentity? ClientIdentity { get; set; }
        public int? LegalFormID { get; set; }
        public ClientLegalForm? ClientLegalForm { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int? CountryID { get; set; }
        public ClientCountry? Country { get; set; }
        public int? ResidenceCountryID { get; set; }
        public ClientCountry? ResidenceCountry { get; set; }
        public int? MaritalStatusID { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }
        public string? MobilePhone { get; set; }
        public string? LandlinePhone { get; set; }
        public string? WorkPhone { get; set; }
        public string? Email { get; set; }
        public int? ResidencyStatusID { get; set; }
        public ResidencyStatus? ResidencyStatus { get; set; }
        public bool? IsOwner { get; set; }
        public bool? IsTenant { get; set; }
        public decimal? RequestedAmount { get; set; }
        public string? CompanyName { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyCity { get; set; }
        public int? CompanyCountryID { get; set; }
        public ClientCountry? CompanyCountry { get; set; }
        public decimal? SocialCapital { get; set; }
        public int? BusinessActivityID { get; set; }
        public BusinessActivity? BusinessActivity { get; set; }
        public string? CIN { get; set; }
        public string? ResidencePermit { get; set; }
        public string? PassportNumber { get; set; }
        public int? RoleID { get; set; }
        public ClientRole? Role { get; set; }
        public bool? is_individual { get; set; }
        public bool? is_organisation { get; set; }
        public int? OriginID { get; set; }
        public ClientOrigin? Origin { get; set; }
        public string? OriginDetails { get; set; }
        public ICollection<ClientManager>? ClientManagers { get; set; } = new List<ClientManager>();

    }
}
