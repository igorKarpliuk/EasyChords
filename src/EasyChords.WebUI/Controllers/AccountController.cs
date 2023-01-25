using Azure.Core;
using EasyChords.Core.DTO;
using EasyChords.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyChords.WebUI.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
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
		public async Task <IActionResult> Register(RegisterDTO registerDTO)
		{
			if(!ModelState.IsValid)
			{
				ViewBag.Errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
				return View(registerDTO);
			}
			User user = new User()
			{
				UserName = registerDTO.Email,
				FirstName = registerDTO.FirstName,
				LastName = registerDTO.LastName,
				DateOfBirth = registerDTO.DateOfBirth,
				Email = registerDTO.Email
			};
			IdentityResult result = await _userManager.CreateAsync(user, registerDTO.Password);
			if(result.Succeeded)
			{
				await _signInManager.SignInAsync(user, registerDTO.KeepSignedIn);
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
			else
			{
				foreach(IdentityError error in result.Errors)
				{
					ModelState.AddModelError("Register", error.Description);
				}
			}
			return View(registerDTO);
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginDTO loginDTO)
		{
			if (!ModelState.IsValid) 
			{
				ViewBag.Errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
				return View(loginDTO);
			}
			var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, loginDTO.KeepSignedIn, false);
			if(result.Succeeded)
			{
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
			ModelState.AddModelError("Login", "Invalid email or password");
			return View(loginDTO);
		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(HomeController.Index), "Home");
		}
	}
}
