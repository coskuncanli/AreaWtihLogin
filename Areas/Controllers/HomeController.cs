using Areas.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Areas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            User? x = UserInit.Init().FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            if (x != null)
            {
                var scheme = CookieAuthenticationDefaults.AuthenticationScheme;

                var Claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var claimsIdentity = new ClaimsIdentity(Claims, scheme);
                var authProoerties = new AuthenticationProperties();

                await HttpContext.SignInAsync(scheme, new ClaimsPrincipal(claimsIdentity), authProoerties);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                ViewBag.LoginError = "Hatalı kullanıcı adı ya da şifre";
            }
            return View(); ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}