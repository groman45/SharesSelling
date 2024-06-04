
using AutoMapper;
using SharesSelling.Application.Interfaces;
using SharesSelling.Application.Repositories;
using SharesSelling.Application.DTOs;
using SharesSelling.Application.Strategies;
using System.ComponentModel;
using SharesSelling.Domain.Interfaces;
using SharesSelling.Application.Enums;

namespace SharesSelling.Application.Services
{
    /// <summary>
    /// This class contains methods that execute the business logic of application.
    /// </summary>
    public class StockSaleService : IStockSaleService
    {
        private readonly IMapper _mapper;
        private readonly IStockLotRepository _repo;
        public StockSaleService(IMapper mapper, IStockLotRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public IEnumerable<StockLotDto> GetAllStockLots()
        {           
            return _mapper.Map<IEnumerable<StockLotDto>>(_repo.GetAllStockLots());
        }

        protected ISaleCalculationStrategy CreateStrategy(SaleCalculationStrategyType StrategyId)
        {
            switch (StrategyId)
            {
                case Enums.SaleCalculationStrategyType.FIFO:
                    return new FifoSaleStrategy();                   
                case Enums.SaleCalculationStrategyType.LIFO:
                   return new LifoSaleStrategy();                  
            }
            return new FifoSaleStrategy(); // Default
        }

        public SaleResultDto SellStocks(SaleRequestDto saleRequest)
        {
            StockSaleContext context = new StockSaleContext(_repo.GetAllStockLots());
            context.SaleStrategy = CreateStrategy(saleRequest.StrategyId);            
            var saleResult = context.SellStocks(saleRequest.NumberOfShares, saleRequest.PricePerShare);

            var dto = _mapper.Map<SaleResultDto>(saleResult);
            dto.SoldNumberOfShares = saleRequest.NumberOfShares; // Init extra field, exists only in DTO
                                                                 // Added specifically to demonstrate that DTOs provide a connection
                                                                 // between layers and protect against unnecessary changes:
                                                                 // the abstraction in the Domain component is protected from changes in the Presentation.
            return dto;
        }
    }
}
