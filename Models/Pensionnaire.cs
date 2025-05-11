namespace credirect_api.Models
{
    public class Pensionnaire
    {
        public int Id { get; set; }
        public string? NaturePension { get; set; }
        public int? OrganismePension { get; set; }
        public int? TypePension { get; set; }
        public decimal? Montant { get; set; }

        public int? ClientID { get; set; }
        public Client? Client { get; set; }
    }
}
