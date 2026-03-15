using System.ComponentModel.DataAnnotations;
using IntlTelInputBlazor;
using IntlTelInputBlazor.Validation;

namespace SimpleNumberInput.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [IntlTelephone(ErrorMessage = "Please enter a valid phone number")]
        public IntlTel Phone { get; set; }
    }
}
