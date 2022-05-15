using Microsoft.AspNetCore.Mvc;

namespace AnimeFlix.App.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
