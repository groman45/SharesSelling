using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SharesSelling.Application.DTOs;
using SharesSelling.Application.Interfaces;
using System.Diagnostics;

namespace SharesSelling.WebPresentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStockSaleService _service;

        public HomeController(ILogger<HomeController> logger, IStockSaleService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            this.ViewBag.stockData = _service.GetAllStockLots();
            return View();          
        }

        [HttpPost]
        public IActionResult Index(SaleRequestDto saleRequest)
        {
            if (!ModelState.IsValid) // Validate model
            {
                this.ViewBag.stockData = _service.GetAllStockLots();
                return View(saleRequest);
            }

            var result = _service.SellStocks(saleRequest); // Call business logic
            return RedirectToAction("SaleResult", "Home", result); // Redirect to view results
        }

        [HttpGet]
        public IActionResult SaleResult(SaleResultDto saleResult)
        {
            return View(saleResult);
        }

        // Here is what a controller for a web API might look like.
        //public ActionResult<SaleResultDto> Post([FromBody] SaleRequestDto saleRequest)
        //{
        //    var result = _service.SellStocks(saleRequest);
        //    return Ok(result);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}