const inputs = [];

export function init(element, options, dotNetRef) {
    const itiOptions = {
        allowDropdown: options.allowDropdown,
        allowedNumberTypes: options.allowedNumberTypes,
        allowNumberExtensions: options.allowNumberExtensions,
        allowPhonewords: options.allowPhonewords,
        autoPlaceholder: options.autoPlaceholder,
        containerClass: options.containerClass,
        countryNameLocale: options.countryNameLocale,
        countrySearch: options.countrySearch,
        countryOrder: options.countryOrder,
        dropdownAlwaysOpen: options.dropdownAlwaysOpen,
        excludeCountries: options.excludeCountries,
        fixDropdownWidth: options.fixDropdownWidth,
        formatAsYouType: options.formatAsYouType,
        formatOnDisplay: options.formatOnDisplay,
        initialCountry: options.initialCountry,
        i18n: options.i18n,
        nationalMode: options.nationalMode,
        onlyCountries: options.onlyCountries,
        placeholderNumberType: options.placeholderNumberType,
        searchInputClass: options.searchInputClass,
        separateDialCode: options.separateDialCode,
        showFlags: options.showFlags,
        strictMode: options.strictMode,
        useFullscreenPopup: options.useFullscreenPopup,
        loadUtils: () => import("./utils.js")
    };

    // Handle geoIpLookup if enabled
    if (options.useGeoIpLookup && options.geoIpLookupUrl) {
        itiOptions.initialCountry = "auto";
        itiOptions.geoIpLookup = (success, failure) => {
            fetch(options.geoIpLookupUrl)
                .then(res => res.json())
                .then(data => {
                    const countryCode = data.country_code || data.country || data.countryCode;
                    if (countryCode) {
                        success(countryCode);
                    } else {
                        failure();
                    }
                })
                .catch(() => failure());
        };
    }

    // Remove null/undefined values so intl-tel-input uses its own defaults
    Object.keys(itiOptions).forEach(key => {
        if (itiOptions[key] === null || itiOptions[key] === undefined) {
            delete itiOptions[key];
        }
    });

    const iti = window.intlTelInput(element, itiOptions);
    const id = inputs.length;
    inputs.push(iti);

    // Wire up event listeners that invoke .NET callbacks
    if (dotNetRef) {
        element.addEventListener("countrychange", () => {
            const countryData = iti.getSelectedCountryData();
            dotNetRef.invokeMethodAsync("OnCountryChangeCallback", countryData);
        });

        element.addEventListener("open:countrydropdown", () => {
            dotNetRef.invokeMethodAsync("OnDropdownOpenCallback");
        });

        element.addEventListener("close:countrydropdown", () => {
            dotNetRef.invokeMethodAsync("OnDropdownCloseCallback");
        });
    }

    return id;
}

export function get(id) {
    const input = inputs[id];
    if (!input) return null;

    const number = input.getNumber();
    const isValid = input.isValidNumber();
    const validationError = input.getValidationError();
    const countryData = input.getSelectedCountryData();
    const extension = input.getExtension();
    const numberType = input.getNumberType();

    return { isValid, number, validationError, countryData, extension, numberType };
}

export function setNumber(id, number) {
    const input = inputs[id];
    if (input) input.setNumber(number);
}

export function setCountry(id, iso2) {
    const input = inputs[id];
    if (input) input.setCountry(iso2);
}

export function setDisabled(id, disabled) {
    const input = inputs[id];
    if (input) input.setDisabled(disabled);
}

export function setPlaceholderNumberType(id, type) {
    const input = inputs[id];
    if (input) input.setPlaceholderNumberType(type);
}

export function getNumber(id, format) {
    const input = inputs[id];
    if (!input) return "";
    return input.getNumber(format);
}

export function getSelectedCountryData(id) {
    const input = inputs[id];
    if (!input) return null;
    return input.getSelectedCountryData();
}

export function getValidationError(id) {
    const input = inputs[id];
    if (!input) return -99;
    return input.getValidationError();
}

export function isValidNumber(id) {
    const input = inputs[id];
    if (!input) return false;
    return input.isValidNumber();
}

export function isValidNumberPrecise(id) {
    const input = inputs[id];
    if (!input) return false;
    return input.isValidNumberPrecise();
}

export function getExtension(id) {
    const input = inputs[id];
    if (!input) return "";
    return input.getExtension();
}

export function getNumberType(id) {
    const input = inputs[id];
    if (!input) return -99;
    return input.getNumberType();
}

export function destroy(id) {
    const input = inputs[id];
    if (input) {
        input.destroy();
        inputs[id] = null;
    }
}
