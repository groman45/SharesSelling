using SharesSelling.Domain.Entities;
using Moq;
using SharesSelling.Application.Repositories;
using SharesSelling.Application.Services;
using AutoMapper;
using SharesSelling.Application;

namespace SharesSelling.UnitTest
{
    [TestClass]
    public class StockSaleServiceTests
    {
        private List<StockLot> entities = new List<StockLot>{
                new StockLot  { Id = 1, StockTicker = "MSFT", Price = 20, Count = 100, Date = new DateTime(2024, 1, 1)  },
                new StockLot  { Id = 2, StockTicker = "MSFT", Price = 30, Count = 150, Date = new DateTime(2024, 2, 1)  },
                new StockLot  { Id = 3, StockTicker = "MSFT", Price = 10, Count = 120, Date = new DateTime(2024, 3, 1)  },
                };

        private Mock<IStockLotRepository> mockStockRepository;
        private IMapper mapper;

        public StockSaleServiceTests() 
        {
            mockStockRepository = new Mock<IStockLotRepository>();
            mockStockRepository.Setup(mr => mr.GetAllStockLots()).Returns(entities);

            var myProfile = new MappingProfiles();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);
        }


        [TestMethod]
        public void TestFifo()
        {
            var stockSaleService = new StockSaleService(mapper, mockStockRepository.Object);
            var sellResultDto = stockSaleService.SellStocks(new Application.DTOs.SaleRequestDto()
            {
                NumberOfShares = 100,
                PricePerShare = 25,
                StrategyId = Application.Enums.SaleCalculationStrategyType.FIFO
            });

            Assert.AreEqual(500, sellResultDto.Profit, "Failed on the following test case: Profit");
            Assert.AreEqual(100, sellResultDto.SoldNumberOfShares, "Failed on the following test case: SoldNumberOfShares");
            Assert.AreEqual(20, sellResultDto.CostBasisSoldShares, "Failed on the following test case: CostBasisSoldShares");
            Assert.AreEqual(270, sellResultDto.RemainingNumberOfShares, "Failed on the following test case: RemainingNumberOfShares");
            Assert.AreEqual(21.11M, Math.Round(sellResultDto.CostBasisRemainingShares, 2), "Failed on the following test case: CostBasisRemainingShares");
        }

        [TestMethod]
        public void TestLifo()
        {
            var stockSaleService = new StockSaleService(mapper, mockStockRepository.Object);
            var sellResultDto = stockSaleService.SellStocks(new Application.DTOs.SaleRequestDto()
            {
                NumberOfShares = 50,
                PricePerShare = 25,
                StrategyId = Application.Enums.SaleCalculationStrategyType.LIFO
            });

            Assert.AreEqual(750, sellResultDto.Profit, "Failed on the following test case: Profit");
            Assert.AreEqual(50, sellResultDto.SoldNumberOfShares, "Failed on the following test case: SoldNumberOfShares");
            Assert.AreEqual(10, sellResultDto.CostBasisSoldShares, "Failed on the following test case: CostBasisSoldShares");
            Assert.AreEqual(320, sellResultDto.RemainingNumberOfShares, "Failed on the following test case: RemainingNumberOfShares");
            Assert.AreEqual(22.50M, Math.Round(sellResultDto.CostBasisRemainingShares, 2), "Failed on the following test case: CostBasisRemainingShares");
        }
    }
}