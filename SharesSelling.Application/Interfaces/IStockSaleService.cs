using SharesSelling.Application.DTOs;

namespace SharesSelling.Application.Interfaces
{
    public interface IStockSaleService
    {
        IEnumerable<StockLotDto> GetAllStockLots();
        SaleResultDto SellStocks(SaleRequestDto saleRequest);
    }
}
