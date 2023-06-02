

using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreAndFood.Controllers
{
    public class LoginController : Controller
    {
		Context c = new Context();
		[AllowAnonymous] // Bütün actionResultları bütün controllerları Authorizate işlemine tabii tut ama bu sayfa hariç
		public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Index(Admin p)
		{
			var dataValue = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
			if (dataValue != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, p.UserName),
				};
				var userIdentity = new ClaimsIdentity(claims, "Login");
				ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Category"); //category içindeki index actionuna yönlendir.
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> LogOut()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Login");
		}
	}
}
