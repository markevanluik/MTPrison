using MTPrison.Data.Party;

namespace MTPrison.Domain.Party {
    public interface ICountriesRepo : IRepo<Country> { }
    public sealed class Country : NamedEntity<CountryData> {
        public Country() : this(new CountryData()) { }
        public Country(CountryData d) : base(d) { }
    }
}
