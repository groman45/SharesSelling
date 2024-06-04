using SharesSelling.Domain.Entities;
using SharesSelling.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharesSelling.Application.Strategies
{
    /// <summary>
    /// The context class that uses the strategy to calculate profit.
	/// Goal: We easily can change the calculation strategy without modifying the code that uses this strategy.
    /// </summary>
    public class StockSaleContext
	{
		private readonly List<StockLot> entities;
		public StockSaleContext(List<StockLot> entities)
		{
			this.entities = entities;
		}

		public ISaleCalculationStrategy SaleStrategy { get; set; } = null!;

		// Perform sort
		public SaleResult SellStocks(int count, decimal price)
		{
			return SaleStrategy.CalculateProfit(entities, count, price);
		}
	}
}
