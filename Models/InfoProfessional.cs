namespace credirect_api.Models
{
    public class InfoProfessional
    {
        public int InfoProfessionalID { get; set; }
        public int ClientID { get; set; }

        // Salarie Information
        public bool? IsSalarie { get; set; }
        public string? Position { get; set; }
        public string? Employer { get; set; }
        public DateTime? HiringDate { get; set; }
        public decimal? Salary { get; set; }

        // Commerçant Personne Physique Information
        public bool? IsCommercant { get; set; }
        public string? TradeName { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? BusinessAddressCommercant { get; set; }

        // Profession Libérale Information
        public bool? IsProfessionLiberale { get; set; }
        public string? ActivityName { get; set; }
        public string? TaxID { get; set; }
        public string? OfficeAddress { get; set; }

        // Gérant de Société Information
        public bool? IsGerantSociete { get; set; }
        public string? CompanyName { get; set; }
        public DateTime? CompanyCreationDate { get; set; }
        public string? BusinessAddressGerantSociete { get; set; }
        public decimal? LastYearRevenue { get; set; }
        public decimal? SecondLastYearRevenue { get; set; }

        // Retraité ou Pensionnaire Information
        public bool? IsRetraite { get; set; }
        public decimal? PensionAmount { get; set; }
        public string? RetireeType { get; set; }

        // Common Attributes
        public string? PropertyNature { get; set; }
        public string? PropertyLocation { get; set; }
        public decimal? PropertyValue { get; set; }

        public Client? Client { get; set; }
    }

}
