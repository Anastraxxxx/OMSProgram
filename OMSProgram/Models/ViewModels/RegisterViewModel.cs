using System.ComponentModel.DataAnnotations;

namespace OMSProgram.Models.ViewModels
{
	public class RegisterViewModel
	{
		[Display(Name = "Имейл")]
		[Required(ErrorMessage = "Имайла е задължителен!")]
		public string Email { get; set; }

		[Display(Name = "Псевдоним")]
		[Required(ErrorMessage = "Псевдонима е задължителен!")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Псевдонима трябва да е с големина между 3 и 50 букви!!!")]
		public string UserName { get; set; }

		[Required]
		[Display(Name = "Парола")]
		[DataType(DataType.Password)]
		[StringLength(100, ErrorMessage = "Паролата {0} трябва да пъде поне {2} цифри и букви.", MinimumLength = 6)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Потвърди паролата")]
		[Compare("Password", ErrorMessage = "Двете пароли не съвпадат.")]
		public string ConfirmPassword { get; set; }

		[Display(Name = "Име")]
		[Required(ErrorMessage = "Името е задължително!")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Името трябва да е с големина между 3 и 50 букви!!!")]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Роля")]
		public string RoleName { get; set; }
	}
}
