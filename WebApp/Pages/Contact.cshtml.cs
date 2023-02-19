using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using WebApp.Services;

namespace WebApp.Pages
{
    [BindProperties]
    public class ContactModel : PageModel
    {
        private readonly IMailServices mailServices;
        public ContactModel(IMailServices mailServices)
        {
            this.mailServices = mailServices;
        }
        [Required(ErrorMessage = "Du m�ste ange ditt namn")]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Du m�ste ange din e-mail")]
        [EmailAddress(ErrorMessage = "Din e-mail �r skriven i fel format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Du m�ste ange ett �mne")]
        [MaxLength(20)]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Du m�ste skriva ett meddelande")]
        [MaxLength(300)]
        public string Message { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                mailServices.SendMessage(Email, Name, Subject, Message);

                ViewData["MessageToUser"] = "Ditt meddelande �r nu skickat!";
                //ModelState.Clear(); fungerar ej?
                
            }
            else
            {
                ViewData["MessageToUser"] = "";
            }

        }

    }
}
