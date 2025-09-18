using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class LoginController : BaseUnauthorizedController 
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
