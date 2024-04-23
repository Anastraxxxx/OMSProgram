using OMSProgram.Models.ViewModels;

namespace OMSProgram.Models
{
	public class UserShopObject
	{
		public int Theme {  get; set; }
		public string ShopName {  get; set; }
		public string Description {  get; set; }
		public string CountType {  get; set; }
		public List<Product> UserProd = new List<Product> { };
	}
}
