namespace credirect_api.Models
{
    public class DepotStatus
    {
        public int DepotStatusID { get; set; }

        public int? CreditDepotID { get; set; }
        public CreditDepot? CreditDepot { get; set; }

        public int? CreditID { get; set; }
        public Credit? Credit { get; set; }

        public int? statusDepot { get; set; }

        public int? is_Accord { get; set; }

        public DateTime? dateEnvoi { get; set; }

        public string? comment { get; set; }
    }
}