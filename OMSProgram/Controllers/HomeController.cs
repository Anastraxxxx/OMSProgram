using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OMSProgram.Data;
using OMSProgram.Models;
using OMSProgram.Models.ViewModels;
using System.Diagnostics;

namespace OMSProgram.Controllers
{
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, ILogger<HomeController> logger)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		 public async Task<IActionResult> Delete(string id)
		 {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
			return View(user);
         }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(ApplicationUser user)
        {
			if (user == null)
				return NotFound();

            IdentityResult result = await _userManager.DeleteAsync(user);

			if (result.Succeeded)
			{
                _db.SaveChanges();
                return RedirectToAction("Accounts", "Home");
            }

			Console.WriteLine("Didn't work!!!");
			return RedirectToAction("Accounts", "Home");
        }

        public IActionResult ShopCheck()
		{
            List<string> userId = new List<string>();
			List<string> userIdBack = new List<string>();
			var shops = _db.Shops.ToList();
            var roles = _db.Roles.ToArray()[2].Id;

            foreach (var user in _db.UserRoles)
            {
                if (user.RoleId == roles)
                {
                    userId.Add(user.UserId);
                }
            }

			userIdBack = userId;

			if (userId.Count > shops.Count)
			{
				for (int i = 0; i < userId.Count; i++)
				{
					for (int j = 0; j < shops.Count; j++)
					{
						if (userId[i] == shops[j].UserId)
						{
							userIdBack.Remove(userId[i]);
						}
					}
				}


				foreach (var user in userIdBack)
				{
                    Console.WriteLine(user+ " has been added");
                    _db.Shops.Add(new Models.Shop
					{
						UserId = user,
						Theme = 0,
						Name = " ",
						Description = " ",
					});
				}

				_db.SaveChanges();
			}

            return RedirectToAction("Index");
		}

        public IActionResult Shop()
		{
			List<Shop> model = _db.Shops.ToList();
			return View(model);
		}

		public IActionResult MyShop()
		{
			List<Product> products = new List<Product>();
			var user = User.Claims.First();

			foreach (var item in _db.Products)
			{
				if (item.UserId == user.Value)
				{
					products.Add(item);
				}
			}
            return View(products);
		}

        public IActionResult Accounts()
        {
			var users = _db.Users.ToList();
            return View(users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
