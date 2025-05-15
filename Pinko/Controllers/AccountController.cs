using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pinko.Database.Models.Account;
using Pinko.Database.ViewModels;

namespace Pinko.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<PinkoUser> _userManager;
    private readonly SignInManager<PinkoUser> _signInManager;

    public AccountController(UserManager<PinkoUser> userManager, SignInManager<PinkoUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = new PinkoUser()
        {
            Name = model.Name,
            Surname = model.Surname,
            Email = model.Email,
            UserName = model.Username
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Something went wrong");
            return View(model);
        }


        await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
        return RedirectToAction("Index", "Home");

    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);


        var user = await _userManager.FindByNameAsync(model.UsernameOrEmail);

        if (user is null)
            user = await _userManager.FindByEmailAsync(model.UsernameOrEmail);

        if (user is null)
        {
            ModelState.AddModelError("", "Email or Username incorrect");
            return View(model);
        }

        await _signInManager.PasswordSignInAsync(user, model.Password, model.IsPersistent, false);
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
