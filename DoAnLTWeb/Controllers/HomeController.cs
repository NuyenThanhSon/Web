using DoAnLTWeb.Models;
using DoAnLTWeb.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoAnLTWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly CsdlwebContext _context;
        private readonly IWarehousedetailRepository _warehousedetailRepository;
        private readonly ILogger<HomeController> _logger;
        private readonly IProductTypeRepository _productTypeRepository;


        public HomeController(ILogger<HomeController> logger, CsdlwebContext context, IWarehousedetailRepository warehousedetailRepository)
        {
            _logger = logger;
            _context = context;
            _warehousedetailRepository = warehousedetailRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = _context.Products.ToList();
            var warehousedetail =await  _warehousedetailRepository.GetAllAsync();
            ViewBag.warehousedetail = warehousedetail;
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
