namespace SharesSelling.Application.DTOs
{
    public class StockLotDto
    {
        //public int Id { get; set; }
        public string StockTicker { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
    }
}
