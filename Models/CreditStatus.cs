namespace credirect_api.Models
{
	public class CreditStatus
	{
		public int CreditStatusID { get; set; }
		public string? message { get; set; }
		public int? status { get; set; }
		public int? is_accord { get; set; }
		public int? is_accord_client { get; set; }
		public int id_credit { get; set; }
		public Credit? Credit { get; set; }
		public int id_depot { get; set; }
		public CreditDepot? CreditDepot { get; set; }
		public DateTime? created_at { get; set; }
		public int? created_by { get; set; }
		public int? user_bo_id { get; set; }
		public UserBO? bo_user { get; set; }
		public DateTime? updated_at { get; set; }
		public int? updated_by { get; set; }
		public DateTime? deleted_at { get; set; }
		public int? deleted_by { get; set; }

	}

}

