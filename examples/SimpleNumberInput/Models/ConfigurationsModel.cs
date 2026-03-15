using IntlTelInputBlazor;

namespace SimpleNumberInput.Models
{
    public class ConfigurationsModel
    {
        public IntlTel SeparateDialCode { get; set; }
        public IntlTel InternationalMode { get; set; }
        public IntlTel StrictMode { get; set; }
        public IntlTel CountryOrder { get; set; }
        public IntlTel OnlyCountries { get; set; }
        public IntlTel ExcludeCountries { get; set; }
        public IntlTel NoDropdown { get; set; }
        public IntlTel NoFlags { get; set; }
        public IntlTel NoSearch { get; set; }
        public IntlTel FixedLinePlaceholder { get; set; }
        public IntlTel PlaceholderOff { get; set; }
        public IntlTel FormatOff { get; set; }
        public IntlTel FormatOn { get; set; }
        public IntlTel DropdownFixed { get; set; }
        public IntlTel DropdownAuto { get; set; }
        public IntlTel CustomContainer { get; set; }
        public IntlTel MobileOnly { get; set; }
    }
}
