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
        [Required(ErrorMessage = "Du måste ange ditt namn")]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Du måste ange din e-mail")]
        [EmailAddress(ErrorMessage = "Din e-mail är skriven i fel format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Du måste ange ett Ämne")]
        [MaxLength(20)]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Du måste skriva ett meddelande")]
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

                ViewData["MessageToUser"] = "Ditt meddelande är nu skickat!";
                //ModelState.Clear(); fungerar ej?
                
            }
            else
            {
                ViewData["MessageToUser"] = "";
            }

        }

    }
}
