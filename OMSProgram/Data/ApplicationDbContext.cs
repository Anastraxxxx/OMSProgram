using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OMSProgram.Models;
using OMSProgram.Models.ViewModels;

namespace OMSProgram.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
		{ 

		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Shop> Shops { get; set; }
    }
}
