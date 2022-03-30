using MTPrison.Data.Party;

namespace MTPrison.Domain.Party {
    public interface ICountriesRepo : IRepo<Country> { }
    public class Country : UniqueEntity<CountryData> {
        public Country() : this(new CountryData()) { }
        public Country(CountryData d) : base(d) { }
        public string? Code => getValue(Data?.Code);
        public string? Name => getValue(Data?.Name);
        public string? NativeName => getValue(Data?.NativeName);
    }
}
