using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OMSProgram.Models
{
	public class Shop
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string UserId {  get; set; }
		[DefaultValue(0)]
		[Display(Name ="Дизайн номер: ")]
		public int Theme {  get; set; }
		[StringLength(30, MinimumLength = 0, ErrorMessage = "Името трябва да е до 30 букви!")]
		[Display(Name = "Име")]
		public string Name { get; set; }
		[AllowNull]
		[Display(Name ="Описание на магазина")]
		public string Description { get; set; }
	}
}
