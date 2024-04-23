using Microsoft.AspNetCore.Mvc.Rendering;

namespace OMSProgram.Utility
{
	public static class Helper
	{
		public static string Admin = "Admin";
		public static string User = "User";
		public static string ShKeeper = "ShKeeper";

		public static int First = 0;
		public static int Second = 1;
		public static int Third = 2;
		public static int Fourth = 3;

		public static List<SelectListItem> GetRolesForDropDown()
		{
			return new List<SelectListItem>
			{
				new SelectListItem{Value = Helper.User, Text=Helper.User},
				new SelectListItem {Value = Helper.ShKeeper, Text=Helper.ShKeeper}
			};
		}
		public static List<SelectListItem> GetThemesForDropDown()
		{
			return new List<SelectListItem>
			{
				new SelectListItem{Value = Helper.First.ToString(), Text=Helper.First.ToString()},
				new SelectListItem{Value = Helper.Second.ToString(), Text=Helper.Second.ToString()},
				new SelectListItem{Value = Helper.Third.ToString(), Text=Helper.Third.ToString()},
				new SelectListItem{Value = Helper.Fourth.ToString(), Text=Helper.Fourth.ToString()}
			};
		}
	}
}
