using Microsoft.AspNetCore.Mvc;
using Spg.SpengerDo.App.Account.Business;
using Spg.SpengerDo.App.Model;
using Spg.SpengerDo.App.Presentation;

namespace Spg.SpengerDo.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginLogic _login;

        public AccountController(ILoginLogic login)
        {
            _login = login;
        }

        [HttpGet()]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost()]
        public IActionResult Login(LoginCredentials credentials)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            User? user = null;
            try
            {
                user = _login.LoginUser(credentials);
            }
            catch (LoginException ex)
            {
                ModelState.AddModelError("nf", ex.Message);
            }
            return RedirectToAction("Index", "Todo", new { UserId = user?.Id });
        }
    }
}
