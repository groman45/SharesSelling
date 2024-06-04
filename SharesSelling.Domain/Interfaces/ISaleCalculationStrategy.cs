using SharesSelling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SharesSelling.Domain.Interfaces
{
    /// <summary>
    /// The strategy interface that defines the method for calculating profit.    
    /// This abstraction is key to the domain, therefore it is declared in this layer.
    /// </summary>
    public interface ISaleCalculationStrategy
	{
		SaleResult CalculateProfit(List<StockLot> entities, int count, decimal price);
	}
}
