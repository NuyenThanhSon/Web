using Microsoft.AspNetCore.Mvc;

namespace DoAnLTWeb.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class handleErrorController : Controller
    {
        public IActionResult permissiondenied()
        {
            return View();
        }



        public IActionResult NotFound()
        {
            return View();
        }

    }
}
