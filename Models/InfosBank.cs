namespace credirect_api.Models
{
    public class InfosBank
    {
        public int InfoBankID { get; set; }
        public int? AgencyBankID { get; set; }
        public string? AgencyName { get; set; }
        public int? ClientID { get; set; }
        public decimal? Balance { get; set; }
        public decimal? CumulativeCreditMovement { get; set; }
        public bool? IsPrincipal { get; set; }

        public AgencyBank? AgencyBank { get; set; }
        public Client? Client { get; set; }
    }

}
