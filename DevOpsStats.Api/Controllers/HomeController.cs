using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
