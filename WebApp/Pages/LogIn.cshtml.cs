using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages
{
    public class LogInModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;
        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LogInModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                
                var identityResult = await signInManager.PasswordSignInAsync(Email, Password, isPersistent: false, false);
                if (identityResult.Succeeded)
                {
                    if(returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        return RedirectToPage(returnUrl);
                    }
                }
                ModelState.AddModelError("", "Användarnamn eller lösenord är inkorrekt");
                
            }
            return Page();
        }
    }
}
