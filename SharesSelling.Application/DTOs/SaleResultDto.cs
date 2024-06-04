namespace SharesSelling.Application.DTOs
{
    public class SaleResultDto
    {
        public bool Succeeded { get; set; }
        public string Error { get; set; }

        public int RemainingNumberOfShares { get; set; }
        public decimal CostBasisRemainingShares { get; set; }
        public int SoldNumberOfShares { get; set; }
        public decimal CostBasisSoldShares { get; set; }        
        public decimal Profit { get; set; }
    }
}
