using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Pages {
    public class CountriesPage : BasePage<CountryView, Country, ICountriesRepo> {
        public CountriesPage(ICountriesRepo r) : base(r) { }
        protected override Country toObject(CountryView? item) => new CountryViewFactory().Create(item);
        protected override CountryView toView(Country? entity) => new CountryViewFactory().Create(entity);
    }
}
