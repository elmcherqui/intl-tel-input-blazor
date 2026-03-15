using IntlTelInputBlazor;

namespace SimpleNumberInput.Models
{
    public class DemoModel
    {
        public IntlTel Phone { get; set; }
    }

    public class MethodsDemoModel
    {
        public IntlTel Phone { get; set; }
    }

    public class EventsDemoModel
    {
        public IntlTel Phone { get; set; }
    }

    public class AdvancedDemoModel
    {
        public IntlTel GeoIp { get; set; }
        public IntlTel LocaleEn { get; set; }
        public IntlTel LocaleDe { get; set; }
        public IntlTel LocaleJa { get; set; }
        public IntlTel I18n { get; set; }
        public IntlTel Extensions { get; set; }
        public IntlTel Phonewords { get; set; }
        public IntlTel AlwaysOpen { get; set; }
        public IntlTel Fullscreen { get; set; }
        public IntlTel Combo { get; set; }
    }

    public class ValidationDemoModel
    {
        public IntlTel ErrorDemo { get; set; }
    }
}
