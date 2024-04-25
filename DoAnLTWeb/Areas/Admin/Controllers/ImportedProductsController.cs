using DoAnLTWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoAnLTWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ImportedProductsController : Controller
    {
        CsdlwebContext db = new CsdlwebContext();
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            ViewBag.ProductIds = db.Products
                .Select(p => new SelectListItem
                {
                    Value = p.Idproduct.ToString(),
                    Text = p.Idproduct.ToString()
                }).ToList();

            ViewBag.StaffIds = db.Staff
                .Select(s => new SelectListItem
                {
                    Value = s.Idstaff.ToString(),
                    Text = s.Idstaff.ToString()
                }).ToList();

            return View();
        }




    }
}
