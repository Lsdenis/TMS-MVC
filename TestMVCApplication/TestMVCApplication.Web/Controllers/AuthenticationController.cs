using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestMVCApplication.Web.Filters;
using TestMVCApplication.Web.Models;

namespace TestMVCApplication.Web.Controllers;

public class AuthenticationController : Controller
{
    [TestActionFilter]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View("Error");
        }

        var user = AuthenticateUser(loginViewModel.Username);

        if (user == null)
        {
            return View("Error");
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, loginViewModel.Username),
            new("AnyTestValueIWantToAdd", "123124"),
            new(ClaimTypes.Role, "Administrator")
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            //AllowRefresh = <bool>,
            // Refreshing the authentication session should be allowed.

            //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            // The time at which the authentication ticket expires. A 
            // value set here overrides the ExpireTimeSpan option of 
            // CookieAuthenticationOptions set with AddCookie.

            //IsPersistent = true,
            // Whether the authentication session is persisted across 
            // multiple requests. When used with cookies, controls
            // whether the cookie's lifetime is absolute (matching the
            // lifetime of the authentication ticket) or session-based.

            //IssuedUtc = <DateTimeOffset>,
            // The time at which the authentication ticket was issued.

            //RedirectUri = <string>
            // The full path or absolute URI to be used as an http 
            // redirect response value.
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        return RedirectToAction("AuthorizedView");
    }

    [Authorize(Roles = "Administrator")]
    public IActionResult AuthorizedView()
    {
        return View();
    }

    [Authorize(Roles = "User")]
    public IActionResult NotAuthorizedView()
    {
        return View();
    }

    public IActionResult Forbidden()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    private UserViewModel? AuthenticateUser(string username)
    {
        return UsersController.StaticUsers.FirstOrDefault(model => model.Username.Equals(username));
    }
}