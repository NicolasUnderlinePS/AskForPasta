using Application.AskForPasta.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class LoginController : BaseUnauthorizedController
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(StartSessionRequestDto model)
        {
            if (ModelState.IsValid == false)
                return View("Index", model);

            return Json(model);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(CreateUserAccessRequestDto model)
        {
            if (ModelState.IsValid == false)
                return View("Index", model);

            return Json(model);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ForgotPassword(CreateUserAccessRequestDto model)
        {
            if (ModelState.IsValid == false)
                return View("Index", model);

            return Json(model);
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }


        public IActionResult ResetPassword(string token)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(CreateUserAccessRequestDto model)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}
