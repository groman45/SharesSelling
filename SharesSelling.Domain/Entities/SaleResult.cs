using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharesSelling.Domain.Entities
{
	public class SaleResult
	{
		internal SaleResult(bool succeeded, string error)
		{
			Succeeded = succeeded;
			Error = error;
		}

		public bool Succeeded { get; init; }
		public string Error { get; init; }

		public int RemainingNumberOfShares { get; set; }
		public decimal CostBasisSoldShares { get; set; }
		public decimal CostBasisRemainingShares { get; set; }
		public decimal Profit { get; set; }

		public static SaleResult Success()
		{
			return new SaleResult(true, string.Empty);
		}

		public static SaleResult Failure(string error)
		{
			return new SaleResult(false, error);
		}
	}
}
