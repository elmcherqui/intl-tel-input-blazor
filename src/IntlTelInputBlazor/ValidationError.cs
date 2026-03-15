namespace IntlTelInputBlazor
{
    /// <summary>
    /// Validation error codes matching intl-tel-input utils.validationError
    /// </summary>
    public enum ValidationError
    {
        IsPossible = 0,
        InvalidCountryCode = 1,
        TooShort = 2,
        TooLong = 3,
        IsPossibleLocalOnly = 4,
        InvalidLength = 5
    }
}
