using System;
using System.Collections.Generic;
using System.Linq;
using SharesSelling.Domain.Interfaces;
using SharesSelling.Domain.Entities;

namespace SharesSelling.Application.Strategies
{
    /// <summary>
    /// This class implements specific strategy (LIFO) for calculating stock sale metrics.
    /// </summary>
    public class LifoSaleStrategy : ISaleCalculationStrategy
	{
		public SaleResult CalculateProfit(List<StockLot> entities, int countSharesToSell, decimal price)
		{
			if (entities == null)
				throw new ArgumentNullException(nameof(entities));
			if (!entities.Any())
				return SaleResult.Failure("You don't have any stocks to sell!");

			int totalAvailableShares = entities.Sum(e => e.Count);
			if (countSharesToSell > totalAvailableShares)
				return SaleResult.Failure("You don't have enough stocks; you are trying to sell more than you own.");


			decimal totalCostOfSoldShares = 0M;
			decimal totalCostOfRemainingShares = 0M;
			decimal totalProfit = 0M;
			int remainingSharesToSell = countSharesToSell;

			foreach (StockLot lot in entities.OrderByDescending(e => e.Date)) // Sort to provide LIFO
			{
				int sharesToSellFromLot = Math.Min(remainingSharesToSell, lot.Count);
				int sharesRemainingInLot = lot.Count - sharesToSellFromLot;

				totalCostOfSoldShares += lot.Price * sharesToSellFromLot;
				totalCostOfRemainingShares += lot.Price * sharesRemainingInLot;
				totalProfit += (price - lot.Price) * sharesToSellFromLot;

				remainingSharesToSell -= sharesToSellFromLot;
			}

			int remainingNumberOfShares = totalAvailableShares - countSharesToSell;

			SaleResult saleResult = SaleResult.Success();
			saleResult.RemainingNumberOfShares = remainingNumberOfShares;
			saleResult.CostBasisSoldShares = countSharesToSell > 0 ? totalCostOfSoldShares / countSharesToSell : 0M;
			saleResult.CostBasisRemainingShares = remainingNumberOfShares > 0 ? totalCostOfRemainingShares / remainingNumberOfShares : 0M;
			saleResult.Profit = totalProfit;

			return saleResult;
		}
	}
}
