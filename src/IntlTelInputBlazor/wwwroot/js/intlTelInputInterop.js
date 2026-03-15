const inputs = [];

export function init(element, options) {
    // Convert PascalCase options from Blazor to camelCase for intl-tel-input
    const itiOptions = {
        allowDropdown: options.AllowDropdown,
        autoPlaceholder: options.AutoPlaceholder,
        containerClass: options.ContainerClass,
        countrySearch: options.CountrySearch,
        countryOrder: options.CountryOrder,
        excludeCountries: options.ExcludeCountries,
        formatOnDisplay: options.FormatOnDisplay,
        formatAsYouType: options.FormatAsYouType,
        initialCountry: options.InitialCountry,
        localizedCountries: options.LocalizedCountries,
        nationalMode: options.NationalMode,
        onlyCountries: options.OnlyCountries,
        placeholderNumberType: options.PlaceholderNumberType,
        separateDialCode: options.SeparateDialCode,
        showFlags: options.ShowFlags,
        strictMode: options.StrictMode,
        loadUtils: () => import("./utils.js")
    };

    // Remove null/undefined values
    Object.keys(itiOptions).forEach(key => {
        if (itiOptions[key] === null || itiOptions[key] === undefined) {
            delete itiOptions[key];
        }
    });

    const iti = window.intlTelInput(element, itiOptions);
    inputs.push(iti);
    return inputs.indexOf(iti);
}

export function get(id) {
    const input = inputs[id];

    const number = input.getNumber();
    const isValid = input.isValidNumber();
    const validationError = input.getValidationError();
    const countryData = input.getSelectedCountryData();
    const numberType = input.getNumberType();

    return {isValid, number, validationError, countryData, numberType};
}

export function setNumber(id, number) {
    const input = inputs[id];
    input.setNumber(number);
}
