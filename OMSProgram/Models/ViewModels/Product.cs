using OMSProgram.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMSProgram.Models.ViewModels
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Името е задължително!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Името трябва да е с големина между 3 и 50 букви!!!")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Цената е задължителна!")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal Price { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        public string CountType {  get; set; }

        [DefaultValue("0")]
        public string UserId { get; set; }
    }
}
