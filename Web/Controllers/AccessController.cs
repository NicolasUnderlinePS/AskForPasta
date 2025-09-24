using Application.AskForPasta.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AccessController : BaseUnauthorizedController
    {
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult ResetPassword(string token)
        {
            return View();
        }
    }
}
