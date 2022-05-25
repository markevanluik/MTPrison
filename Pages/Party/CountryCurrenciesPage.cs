using Microsoft.AspNetCore.Mvc.Rendering;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Pages.Party {
    public sealed class CountryCurrenciesPage : PagedPage<CountryCurrencyView, CountryCurrency, ICountryCurrenciesRepo> {

        private readonly ICountriesRepo countries;
        private readonly ICurrenciesRepo currencies;
        public CountryCurrenciesPage(ICountryCurrenciesRepo r, ICountriesRepo co, ICurrenciesRepo cu) : base(r) {
            countries = co;
            currencies = cu;
        }
        protected override CountryCurrency toObject(CountryCurrencyView? item) => new CountryCurrencyViewFactory().Create(item);
        protected override CountryCurrencyView toView(CountryCurrency? entity) => new CountryCurrencyViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CountryCurrencyView.Code),
            nameof(CountryCurrencyView.Name),
            nameof(CountryCurrencyView.CountryName),
            nameof(CountryCurrencyView.CurrencyName),
            nameof(CountryCurrencyView.NativeName)
        };
        public IEnumerable<SelectListItem> Countries
            => countries?.GetAll()?
            .Select(x => new SelectListItem(x.Name, x.Id)) ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Currencies
            => currencies?.GetAll()?
            .Select(x => new SelectListItem(x.Name, x.Id)) ?? new List<SelectListItem>();
        public string CountryName(string? countryId = null)
            => Countries?.FirstOrDefault(x => x.Value == (countryId ?? string.Empty))?.Text ?? $"No {nameof(Country)}";
        public string CurrencyName(string? currencyId = null)
            => Currencies?.FirstOrDefault(x => x.Value == (currencyId ?? string.Empty))?.Text ?? $"No {nameof(Currency)}";

        public override object? GetValue(string name, CountryCurrencyView v) {
            var r = base.GetValue(name, v);
            return name == nameof(v.CountryId) ? CountryName(r as string)
                 : name == nameof(v.CurrencyId) ? CurrencyName(r as string)
                 : r;
        }
    }
}
