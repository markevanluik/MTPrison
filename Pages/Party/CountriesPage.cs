using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Pages.Party {
    public sealed class CountriesPage : PagedPage<CountryView, Country, ICountriesRepo> {
        public CountriesPage(ICountriesRepo r) : base(r) { }
        protected override Country toObject(CountryView? item) => new CountryViewFactory().Create(item);
        protected override CountryView toView(Country? entity) => new CountryViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CountryView.Code),
            nameof(CountryView.Name),
            nameof(CountryView.NativeName)
        };
        public Lazy<List<Currency?>> Currencies => toObject(Item).Currencies;
    }
}
