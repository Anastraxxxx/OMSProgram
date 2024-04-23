using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OMSProgram.Data;
using OMSProgram.Models;
using OMSProgram.Models.ViewModels;

namespace OMSProgram.Controllers
{
	public class ShopController : Controller
	{
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ShopController(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult AddProduct()
		{
			return View();
		}
		public bool CheckProduct(Product model)
		{
			return model.Name != null && model.UserId != null && model.Price != null && model.Description != null;
		}
		[HttpPost]
		public IActionResult AddProduct(Product model)
		{
            model.UserId = User.Claims.First().Value;
			model.CountType = "smt";

            if (CheckProduct(model))
			{
				_db.Products.Add(model);
				_db.SaveChanges();

				return RedirectToAction("MyShop","Home");
			}

			return View();
		}

		public IActionResult EditShop()
		{
			Shop shop = new Shop();
			foreach (var shops in _db.Shops)
			{
				if (User.Claims.First().Value == shops.UserId)
				{
					shop = shops;
				}
			}

			return View(shop);
		}
		[HttpPost]
		public IActionResult EditShop(Shop shop)
		{
			bool Sh = true;
			Shop sp = new Shop();
			shop.UserId = User.Claims.First().Value;
			foreach (var shops in _db.Shops)
			{
				if (shops.UserId == shop.UserId)
				{
					sp = shops;
					shop.Id = shops.Id;
					Sh = false;
				}
			}

			if (Sh)
			{
				_db.Shops.Add(sp);
			}

			_db.Shops.Remove(sp);
			_db.Shops.Add(shop);
			_db.SaveChanges();
			return RedirectToAction("MyShop","Home");
		}

		public IActionResult AddToCart(string id)
		{

			return RedirectToAction();
		}

		public IActionResult OneShop(string Id)
		{
			UserShopObject shop = new UserShopObject();
			foreach (var users in _db.Shops)
			{
				if (users.UserId == Id)
				{
					shop.Description = users.Description;
					shop.ShopName = users.Name;
					shop.Theme = users.Theme;
				}
			}
			foreach (var shops in _db.Products)
			{
				if (shops.UserId == Id)
				{
					shop.CountType = shops.CountType;
					shop.UserProd.Add(shops);
				}
			}
			return View(shop);
		}
	}
}
