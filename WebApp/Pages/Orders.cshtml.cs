using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages
{
    public class OrdersModel : PageModel
    {

        public List<FoodsModel> FoodOrders = new List<FoodsModel>();

        private readonly ApplicationDbContext _context;
        public OrdersModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            FoodOrders = _context.FoodOrders.ToList();
        }
    }
}
