namespace credirect_api.Models
{
    public class LignCreditProperty
    {
        public int LignCreditPropertyID { get; set; }
        public int CreditID { get; set; }
        public int? ObjectCreditID { get; set; }
        public int? PropertyID { get; set; }
        public bool? IsPrincipal { get; set; }
        public bool? IsObjectCredit { get; set; }
        public bool? IsAdditional { get; set; }
        public bool? IsSubstitution { get; set; }

        public decimal? MontantCredit { get; set; }
        public decimal? DureeCredit { get; set; }
        public int? FrequenceRemboursement { get; set; }
        public decimal? DureeFranchise { get; set; }
        public decimal? TauxCredit { get; set; }
        public bool? DerogationSouhaite { get; set; }
        public int? AssuranceDeczsInvalidite { get; set; }
        public string? CommentCredit { get; set; }
        public string? DerogationSouhaiteeText { get; set; }
        public decimal? honorairesFactures { get; set; }

        public Credit? Credit { get; set; }
        public ObjectCredit? ObjectCredit { get; set; }
        public Property? Property { get; set; }
    }

}
