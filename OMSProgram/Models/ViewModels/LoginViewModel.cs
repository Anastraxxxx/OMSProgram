using System.ComponentModel.DataAnnotations;

namespace OMSProgram.Models.ViewModels
{
	public class LoginViewModel
	{
		[Display(Name = "Псевдоним")]
		[Required(ErrorMessage = "Псевдонима е задължителен!")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Псевдонима трябва да е с големина между 3 и 50 букви!!!")]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		public string Password { get; set; }

		[Display(Name = "Запомни ме")]
		public bool RememberMe { get; set; }
	}
}
