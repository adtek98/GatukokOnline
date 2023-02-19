using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<FoodsModel> FoodOrders { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
	}
}
