# Full-Feature intl-tel-input Blazor Wrapper

> **For agentic workers:** REQUIRED: Use superpowers:subagent-driven-development (if subagents available) or superpowers:executing-plans to implement this plan. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Expose all intl-tel-input v26.8.1 JavaScript features through the Blazor wrapper so consuming projects can use the full API.

**Architecture:** The wrapper consists of 3 layers: (1) C# enums/models for type-safe API, (2) JS interop bridge translating between Blazor and JS, (3) Razor component exposing parameters, methods, and events. Each JS method gets a C# counterpart in the interop service, and the component exposes EventCallbacks for JS events via a .NET-to-JS callback bridge.

**Tech Stack:** .NET 10.0, Blazor (Server + WebAssembly), intl-tel-input v26.8.1, JS Interop

---

## Gap Analysis: Current vs Full API

### Missing Initialization Options (→ Component Parameters)
| Option | Type | Default | Notes |
|--------|------|---------|-------|
| `allowedNumberTypes` | string[] | ["MOBILE","FIXED_LINE"] | Number types for validation |
| `allowNumberExtensions` | bool | false | Allow extensions after number |
| `allowPhonewords` | bool | false | Allow alphanumeric phonewords |
| `countryNameLocale` | string | "en" | Locale for country names |
| `dropdownAlwaysOpen` | bool | false | Keep dropdown permanently open |
| `fixDropdownWidth` | bool | true | Fix dropdown to input width |
| `i18n` | Dictionary | {} | Internationalisation strings |
| `searchInputClass` | string | "" | CSS class for search input |
| `useFullscreenPopup` | bool | auto | Mobile fullscreen popup |
| `geoIpLookup` | callback | null | Needs special JS bridge |
| `hiddenInput` | callback | null | Skip - Blazor handles forms differently |
| `customPlaceholder` | callback | null | Skip - JS callback, not practical from Blazor |
| `dropdownContainer` | element | null | Skip - complex DOM manipulation |

### Missing Instance Methods (→ C# methods on interop + component)
| Method | Returns | Notes |
|--------|---------|-------|
| `destroy()` | void | Cleanup |
| `getExtension()` | string | Extension from number |
| `getNumber(format)` | string | With NumberFormat enum |
| `getSelectedCountryData()` | CountryData | Standalone call |
| `getValidationError()` | ValidationError | Standalone call |
| `isValidNumber()` | bool | Standalone validation |
| `isValidNumberPrecise()` | bool | Strict validation |
| `setCountry(iso2)` | void | Change country |
| `setPlaceholderNumberType(type)` | void | Change placeholder |
| `setDisabled(disabled)` | void | Enable/disable |

### Missing Events (→ EventCallback parameters)
| Event | Notes |
|-------|-------|
| `countrychange` | Country selection changed |
| `open:countrydropdown` | Dropdown opened |
| `close:countrydropdown` | Dropdown closed |

### Missing Enums
| Enum | Values |
|------|--------|
| `NumberFormat` | E164, International, National, Rfc3966 |
| `NumberType` | FixedLine, Mobile, FixedLineOrMobile, TollFree, PremiumRate, SharedCost, Voip, PersonalNumber, Pager, Uan, Voicemail, Unknown |
| `ValidationError` | IsPossible, InvalidCountryCode, TooShort, TooLong, IsPossibleLocalOnly, InvalidLength |
| `PlaceholderMode` | Polite, Aggressive, Off |

### Other Improvements
- Fix `async void OnInput` (fire-and-forget bug)
- Add `AdditionalAttributes` for arbitrary HTML attributes
- Add `CssClass` parameter for input element
- Implement `IAsyncDisposable` on component (call `destroy()`)
- Add `Extension` back to `IntlTel` model (it exists in v26 after all)
- Remove `Priority` from `IntlTelCountryData` (not in v26 country data)

---

## Chunk 1: Enums and Models

### Task 1: Add Enums

**Files:**
- Create: `src/IntlTelInputBlazor/NumberFormat.cs`
- Create: `src/IntlTelInputBlazor/NumberType.cs`
- Create: `src/IntlTelInputBlazor/ValidationError.cs`
- Create: `src/IntlTelInputBlazor/PlaceholderMode.cs`

- [ ] **Step 1: Create NumberFormat enum**
- [ ] **Step 2: Create NumberType enum**
- [ ] **Step 3: Create ValidationError enum**
- [ ] **Step 4: Create PlaceholderMode enum**

### Task 2: Update Models

**Files:**
- Modify: `src/IntlTelInputBlazor/IntlTel.cs`
- Modify: `src/IntlTelInputBlazor/IntlTelCountryData.cs`

- [ ] **Step 1: Update IntlTel** - add Extension, use enum types
- [ ] **Step 2: Update IntlTelCountryData** - remove Priority (not in v26)

### Task 3: Build to verify

- [ ] **Step 1: `dotnet build`** - should pass

---

## Chunk 2: JS Interop Layer

### Task 4: Expand JS interop bridge

**Files:**
- Modify: `src/IntlTelInputBlazor/wwwroot/js/intlTelInputInterop.js`

- [ ] **Step 1: Add all missing init options mapping**
- [ ] **Step 2: Add event listener bridge** (countrychange, open/close dropdown → invoke .NET callback)
- [ ] **Step 3: Add all missing method exports** (destroy, getExtension, getNumber with format, getSelectedCountryData, getValidationError, isValidNumber, isValidNumberPrecise, setCountry, setPlaceholderNumberType, setDisabled)
- [ ] **Step 4: Add geoIpLookup bridge** (JS fetches IP, invokes callback)

### Task 5: Expand C# JS interop service

**Files:**
- Modify: `src/IntlTelInputBlazor/IntlTelInputJsInterop.cs`

- [ ] **Step 1: Add all new method signatures** matching the JS exports
- [ ] **Step 2: Add event registration method** for .NET callbacks

### Task 6: Build to verify

- [ ] **Step 1: `dotnet build`** - should pass

---

## Chunk 3: Razor Component

### Task 7: Add all missing parameters and events

**Files:**
- Modify: `src/IntlTelInputBlazor/IntlTelInput.razor`

- [ ] **Step 1: Add all missing initialization parameters**
- [ ] **Step 2: Add EventCallback parameters** (OnCountryChange, OnDropdownOpen, OnDropdownClose)
- [ ] **Step 3: Add public methods** (SetCountry, SetNumber, SetDisabled, SetPlaceholderNumberType, GetNumber, GetSelectedCountryData, GetValidationError, IsValidNumber, IsValidNumberPrecise, GetExtension, Destroy)
- [ ] **Step 4: Wire up events** in OnAfterRenderAsync
- [ ] **Step 5: Add IAsyncDisposable** to call destroy()
- [ ] **Step 6: Fix async void OnInput** bug
- [ ] **Step 7: Add AdditionalAttributes and CssClass**

### Task 8: Build to verify

- [ ] **Step 1: `dotnet build`** - should pass with 0 warnings, 0 errors

---

## Chunk 4: Update Example App

### Task 9: Update example to showcase new features

**Files:**
- Modify: `examples/SimpleNumberInput/Pages/Index.razor`
- Modify: `examples/SimpleNumberInput/Models/NumberModel.cs`

- [ ] **Step 1: Add event handlers and new parameter usage**
- [ ] **Step 2: Build to verify**
- [ ] **Step 3: Commit all changes**
