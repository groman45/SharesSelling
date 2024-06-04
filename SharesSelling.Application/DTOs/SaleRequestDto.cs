using SharesSelling.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace SharesSelling.Application.DTOs
{
    public class SaleRequestDto
    {
       
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int NumberOfShares { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public decimal PricePerShare { get; set; }

        public SaleCalculationStrategyType StrategyId { get; set; }
    }
}
