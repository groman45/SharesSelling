using SharesSelling.Application.Repositories;
using SharesSelling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SharesSelling.Infrastructure.Repositories
{
    /// <summary>
    /// InMomeryRepository - hard coded values for testting.
	/// This implementation can easily be replaced with a database interaction thanks to dependency inversion.
    /// </summary>
    internal class StockLotInMomeryRepository : IStockLotRepository
	{
		private readonly List<StockLot> entities = new List<StockLot>{
			new StockLot  { Id = 1, StockTicker = "MSFT", Price = 20, Count = 100, Date = new DateTime(2024, 1, 1)  },
			new StockLot  { Id = 2, StockTicker = "MSFT", Price = 30, Count = 150, Date = new DateTime(2024, 2, 1)  },
			new StockLot  { Id = 3, StockTicker = "MSFT", Price = 10, Count = 120, Date = new DateTime(2024, 3, 1)  },
		};

		public List<StockLot> GetAllStockLots()
		{
			return entities;
		}

	}
}
