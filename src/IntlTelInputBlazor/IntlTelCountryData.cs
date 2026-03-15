namespace IntlTelInputBlazor
{
    /// <summary>
    /// Represents country data from the intl-tel-input dropdown
    /// </summary>
    public class IntlTelCountryData
    {
        /// <summary>
        /// The full country name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The international dial code (e.g. "1" for US)
        /// </summary>
        public string DialCode { get; set; }

        /// <summary>
        /// The ISO 3166-1 alpha-2 country code (e.g. "us")
        /// </summary>
        public string Iso2 { get; set; }
    }
}
