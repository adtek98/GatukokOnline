using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class CheckoutModel : PageModel
    {
        public string FoodType { get; set; }
        public int Price { get; set; }
        public string ExtraInfo { get; set; }
        public string Sides { get; set; }

        private readonly ApplicationDbContext _context;
        public CheckoutModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            
            FoodsModel foodOrder = new FoodsModel();
            foodOrder.FoodType = FoodType;
            foodOrder.Price = Price;
            foodOrder.ExtraInfo = ExtraInfo;
            foodOrder.Sides = Sides;
            _context.FoodOrders.Add(foodOrder);
            _context.SaveChanges();
                
        }
    }
}
