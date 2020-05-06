using CollegeScorecard.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CollegeScorecard.Controllers
{
    public class AccountController : Controller
    {


        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("UserProfile");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    //aqui poderia ter alguma requisição para base de dados, estou usando
                    //dados estáticos para não complicar
                    if (user.Login == "lblanco" && user.Senha == "123456")
                    {
                        LoginUser(user);
                        return RedirectToAction("UserProfile");
                    }
                    else
                    {
                        ViewBag.Erro = "Usuário e / ou senha incorretos!";
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Erro = "Ocorreu algum erro ao tentar se logar, tente novamente!";
            }
            return View();
        }


        private async void LoginUser(User user)
        {

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

            identity.AddClaim(new Claim(ClaimTypes.Name, user.Login));
            identity.AddClaim(new Claim(ClaimTypes.Role, "CommonUser"));

            var principal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.ToLocalTime().AddMinutes(10),
                IsPersistent = true,
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal), authProperties);

        }

        [Authorize]
        public IActionResult UserProfile()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}