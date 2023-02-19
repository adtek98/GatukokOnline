using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Pages.Forms
{
    public class PizzaFormModel : PageModel
    {
        [BindProperty]
        public FoodsModel Food { get; set; }
        
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (Food.FoodType == "Vesuvio") Food.Price = 90;
            if (Food.FoodType == "Calzone") Food.Price = 95;
            if (Food.FoodType == "Kebabpizza") Food.Price = 100;
            Food.Sides = "inga";
            if(Food.ExtraInfo == null)
            {
                Food.ExtraInfo = "inga";
            }

            return RedirectToPage("/Checkout/Checkout", new { Food.FoodType, Food.Sides, Food.ExtraInfo, Food.Price });
        }
    }
}
