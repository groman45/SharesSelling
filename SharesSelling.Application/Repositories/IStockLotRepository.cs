using SharesSelling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharesSelling.Application.Repositories
{
	public interface IStockLotRepository
	{
		List<StockLot> GetAllStockLots();
	}
}
