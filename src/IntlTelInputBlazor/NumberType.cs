namespace IntlTelInputBlazor
{
    /// <summary>
    /// Phone number types matching intl-tel-input utils.numberType
    /// </summary>
    public enum NumberType
    {
        FixedLine = 0,
        Mobile = 1,
        FixedLineOrMobile = 2,
        TollFree = 3,
        PremiumRate = 4,
        SharedCost = 5,
        Voip = 6,
        PersonalNumber = 7,
        Pager = 8,
        Uan = 9,
        Voicemail = 10,
        Unknown = -1
    }
}
