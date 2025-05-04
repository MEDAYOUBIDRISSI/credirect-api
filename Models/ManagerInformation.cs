namespace credirect_api.Models
{
    public class ManagerInformation
    {
        public int ManagerID { get; set; }
        public int? ManagerTitleID { get; set; }
        public ClientTitle? ManagerTitle { get; set; }
        public string? ManagerLastName { get; set; }
        public string? ManagerFirstName { get; set; }
        public DateTime? ManagerBirthDate { get; set; }
        public string? ManagerNationality { get; set; }
        public int? Id_Identity { get; set; }
        public ClientIdentity? Identity { get; set; }
        public string? ManagerAddress { get; set; }
        public string? ManagerCity { get; set; }
        public int? ManagerCountryID { get; set; }
        public ClientCountry? ManagerCountry { get; set; }
        public int? ManagerResidenceCountryID { get; set; }
        public ClientCountry? ManagerResidenceCountry { get; set; }
        public int? Id_ManagerMaritalStatus { get; set; }
        public MaritalStatus? ManagerMaritalStatus { get; set; }
        public string? CIN { get; set; }
        public string? CarteSejour { get; set; }
        public string? Passeport { get; set; }
        public ICollection<ClientManager>? ClientManagers { get; set; } = new List<ClientManager>();


    }
}
