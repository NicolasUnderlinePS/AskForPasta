using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
