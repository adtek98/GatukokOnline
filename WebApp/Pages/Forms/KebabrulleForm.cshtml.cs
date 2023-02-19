using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Pages.Forms
{
    public class KebabrulleFormModel : PageModel
    {
        [BindProperty]
        public FoodsModel Food { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            Food.Price = 100;
            Food.Sides = "inga";
            if (Food.ExtraInfo == null)
            {
                Food.ExtraInfo = "inga";
            }

            return RedirectToPage("/Checkout/Checkout", new { Food.FoodType, Food.Sides, Food.ExtraInfo, Food.Price });
        }
    }
}
