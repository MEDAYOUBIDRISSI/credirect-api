namespace credirect_api.Models
{
    public class BankCommitmentsCharges
    {
        public int BankCommitmentChargeID { get; set; }
        public int NatureCommitmentID { get; set; }
        public int? AgencyBankID { get; set; }
        public string? OtherAgency { get; set; }
        public int ClientID { get; set; }
        public decimal? Maturity { get; set; }
        public bool? Outstanding { get; set; }
        public bool? RepayableEarly { get; set; }

        public CreditType? NatureCommitment { get; set; }
        public AgencyBank? AgencyBank { get; set; }
        public Client? Client { get; set; }
    }

}
