namespace credirect_api.Models
{
    public class LignCreditClient
    {
        public int LignCreditClientID { get; set; }
        public int ClientID { get; set; }
        public int CreditID { get; set; }
        public bool? IsPrincipal { get; set; }
        public int? PercentageClient { get; set; }

        public Client? Client { get; set; }
        public Credit? Credit { get; set; }
    }

}
