using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Facade.Party {
    public sealed class CountryView : IsoNamedView { }
    public sealed class CountryViewFactory : BaseViewFactory<CountryView, Country, CountryData> {
        protected override Country toEntity(CountryData d) => new(d);

    }
}
