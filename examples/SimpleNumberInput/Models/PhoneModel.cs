using IntlTelInputBlazor;
using IntlTelInputBlazor.Validation;

namespace SimpleNumberInput.Models
{
    public class PhoneModel
    {
        [IntlTelephone(ErrorMessage = "Please enter a valid phone number")]
        public IntlTel PhoneNumber { get; set; } = new IntlTel
        {
            Number = "",
            IsValid = true
        };
    }
}
