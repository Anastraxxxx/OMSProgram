using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OMSProgram.Data;
using OMSProgram.Models;
using OMSProgram.Models.ViewModels;
using OMSProgram.Utility;

namespace OMSProgram.Controllers
{
	public class AccountController : Controller
	{
		private readonly ApplicationDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AccountController(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
		{
			_db = db;
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		public async Task<IActionResult> Logoff()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Login");
		}

		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
				ModelState.AddModelError("", "Неправилна информация!");
			}
			return View(model);
		}

		public async Task<IActionResult> Register()
		{
			if(!_roleManager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())
			{
				await _roleManager.CreateAsync(new IdentityRole(Helper.Admin));
				await _roleManager.CreateAsync(new IdentityRole(Helper.ShKeeper));
				await _roleManager.CreateAsync(new IdentityRole(Helper.User));
			}
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser
				{
					Name = model.Name,
					UserName = model.UserName,
					Email = model.Email,
				};

				var result = await _userManager.CreateAsync(user, model.Password);

				if (model.RoleName == "ShKeeper")
				{
					Console.WriteLine(user.Id + " has been added");
					_db.Shops.Add(new Models.Shop
					{
						UserId = user.Id,
						Theme = 0,
						Name = " ",
						Description = " ",
					});
				}

				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(user, model.RoleName);
					await _signInManager.SignInAsync(user, isPersistent: false);

					return RedirectToAction("Index", "Home");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}

			return View(model);
		}

	}
}
