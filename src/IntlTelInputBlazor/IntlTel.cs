namespace IntlTelInputBlazor
{
    /// <summary>
    /// Represents the complete state of an intl-tel-input instance
    /// </summary>
    public class IntlTel
    {
        /// <summary>
        /// The telephone number entered by the user in E.164 format
        /// Can be set before rendering the component to pre-populate the input
        /// </summary>
        /// <remarks>
        /// If you set the number, also set IsValid if the number is valid
        /// for validation to work properly the first time
        /// </remarks>
        public string Number { get; set; }

        /// <summary>
        /// Whether the current number is valid
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// The validation error code if the number is invalid
        /// </summary>
        public int ValidationError { get; set; }

        /// <summary>
        /// Data for the currently selected country
        /// </summary>
        public IntlTelCountryData CountryData { get; set; }

        /// <summary>
        /// The extension part of the number, if any
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// The detected number type (mobile, fixed line, etc.)
        /// </summary>
        public int NumberType { get; set; }
    }
}
