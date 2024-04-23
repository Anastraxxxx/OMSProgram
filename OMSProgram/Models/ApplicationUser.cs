using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OMSProgram.Models.ViewModels;

namespace OMSProgram.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string Name {  get; set; }

	}
}
