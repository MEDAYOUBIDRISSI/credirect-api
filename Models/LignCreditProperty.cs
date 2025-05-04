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

        public Credit? Credit { get; set; }
        public ObjectCredit? ObjectCredit { get; set; }
        public Property? Property { get; set; }
    }

}
