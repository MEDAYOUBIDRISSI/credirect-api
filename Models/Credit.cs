﻿namespace credirect_api.Models
{
    public class Credit
    {
        public int CreditID { get; set; }
        public string? Matricule { get; set; }
        public int CreditTypeID { get; set; }
        public decimal? amount { get; set; } = 0;
        public CreditType? CreditType { get; set; }
    }

}
