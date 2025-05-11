namespace credirect_api.Models
{
    public class GarantieCredit
    {
        public int GarantieCreditID { get; set; }

        public string? Label { get; set; }

        public int? CreditID { get; set; } 
        public Credit? Credit { get; set; }
    }

}
