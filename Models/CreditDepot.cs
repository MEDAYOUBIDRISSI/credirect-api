namespace credirect_api.Models
{
    public class CreditDepot
    {
        public int CreditDepotId { get; set; }
        public string? interlocutor { get; set; }
		public string? agence { get; set; }
		public DateTime? date_sent { get; set; }
		public int id_credit { get; set; }
        public Credit? Credit { get; set; }
		public int id_agency_bank { get; set; }
		public AgencyBank? AgencyBank { get; set; }
		public DateTime? created_at { get; set; }
		public int? created_by { get; set; }
		public DateTime? updated_at { get; set; }
		public int? updated_by { get; set; }
		public DateTime? deleted_at { get; set; }
		public int? deleted_by { get; set; }

	}

}
