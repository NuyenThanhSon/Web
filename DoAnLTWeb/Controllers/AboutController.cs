using Microsoft.AspNetCore.Mvc;

namespace DoAnLTWeb.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
