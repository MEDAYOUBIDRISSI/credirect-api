namespace credirect_api.Models
{
    public class CreditRemark
	{
        public int id { get; set; }
        public string? remark { get; set; }
		public bool? from_cc { get; set; }
		public int? id_credit { get; set; }
        public Credit? Credit { get; set; }
		public int? userID { get; set; }
		public UserBO? User_bo { get; set; }

	}

}
