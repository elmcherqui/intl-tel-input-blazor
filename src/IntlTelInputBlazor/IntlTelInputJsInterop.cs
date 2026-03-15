using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace IntlTelInputBlazor
{
    public class IntlTelInputJsInterop : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
        private IJSObjectReference _module;

        public IntlTelInputJsInterop(IJSRuntime jsRuntime)
        {
            _moduleTask = new Lazy<Task<IJSObjectReference>>(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/IntlTelInputBlazor/js/intlTelInputInterop.js").AsTask());
        }

        private async ValueTask<IJSObjectReference> GetModuleAsync()
        {
            _module ??= await _moduleTask.Value;
            return _module;
        }

        public async ValueTask<int> Init(ElementReference reference, object options, DotNetObjectReference<IntlTelInput> dotNetRef)
        {
            var module = await GetModuleAsync();
            return await module.InvokeAsync<int>("init", reference, options, dotNetRef);
        }

        public async ValueTask<IntlTel> GetData(int inputIndex)
        {
            var module = await GetModuleAsync();
            return await module.InvokeAsync<IntlTel>("get", inputIndex);
        }

        public async ValueTask SetNumber(int id, string number)
        {
            var module = await GetModuleAsync();
            await module.InvokeVoidAsync("setNumber", id, number);
        }

        public async ValueTask SetCountry(int id, string iso2)
        {
            var module = await GetModuleAsync();
            await module.InvokeVoidAsync("setCountry", id, iso2);
        }

        public async ValueTask SetDisabled(int id, bool disabled)
        {
            var module = await GetModuleAsync();
            await module.InvokeVoidAsync("setDisabled", id, disabled);
        }

        public async ValueTask SetPlaceholderNumberType(int id, string type)
        {
            var module = await GetModuleAsync();
            await module.InvokeVoidAsync("setPlaceholderNumberType", id, type);
        }

        public async ValueTask<string> GetNumber(int id, int format)
        {
            var module = await GetModuleAsync();
            return await module.InvokeAsync<string>("getNumber", id, format);
        }

        public async ValueTask<IntlTelCountryData> GetSelectedCountryData(int id)
        {
            var module = await GetModuleAsync();
            return await module.InvokeAsync<IntlTelCountryData>("getSelectedCountryData", id);
        }

        public async ValueTask<int> GetValidationError(int id)
        {
            var module = await GetModuleAsync();
            return await module.InvokeAsync<int>("getValidationError", id);
        }

        public async ValueTask<bool> IsValidNumber(int id)
        {
            var module = await GetModuleAsync();
            return await module.InvokeAsync<bool>("isValidNumber", id);
        }

        public async ValueTask<bool> IsValidNumberPrecise(int id)
        {
            var module = await GetModuleAsync();
            return await module.InvokeAsync<bool>("isValidNumberPrecise", id);
        }

        public async ValueTask<string> GetExtension(int id)
        {
            var module = await GetModuleAsync();
            return await module.InvokeAsync<string>("getExtension", id);
        }

        public async ValueTask<int> GetNumberType(int id)
        {
            var module = await GetModuleAsync();
            return await module.InvokeAsync<int>("getNumberType", id);
        }

        public async ValueTask Destroy(int id)
        {
            var module = await GetModuleAsync();
            await module.InvokeVoidAsync("destroy", id);
        }

        public async ValueTask DisposeAsync()
        {
            if (_moduleTask.IsValueCreated)
            {
                var module = await _moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
