namespace credirect_api.Models
{
    public class Property
    {
        public int PropertyID { get; set; }
        public int CreditID { get; set; }
        public string? Adress { get; set; }
        public string? PropertyArea { get; set; }
        public string? LandTitle { get; set; }
        public decimal? SalePriceProperty { get; set; }
        public decimal? RealValueProperty { get; set; }
        public decimal? AmountWork { get; set; }
        public decimal? EstimatedValue { get; set; }
        public int? NaturePropertyID { get; set; }
        public int? AssignmentPropertyID { get; set; }
        public int? UsePropertyID { get; set; }
        public int? ConditionPropertyID { get; set; }
         
        public NatureProperty? NatureProperty { get; set; }
        public AssignmentProperty? AssignmentProperty { get; set; }
        public UseProperty? UseProperty { get; set; }
        public ConditionProperty? ConditionProperty { get; set; }
        public Credit? Credit { get; set; }
    }

}
