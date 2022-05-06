using MTPrison.Data.Party;

namespace MTPrison.Domain.Party {
    public interface ICountriesRepo : IRepo<Country> { }
    public sealed class Country : NamedEntity<CountryData>, IComparable {
        public Country() : this(new()) { }
        public Country(CountryData d) : base(d) { }

        public List<CountryCurrency> CountryCurrencies
            => GetRepo.Instance<ICountryCurrenciesRepo>()?
            .GetAll(x => x.CountryId)?
            .Where(x => x.CountryId == Id)?
            .ToList() ?? new List<CountryCurrency>();

        public List<Currency?> Currencies
            => CountryCurrencies
            .Select(x => x.Currency)
            .ToList() ?? new List<Currency?>();

        public int CompareTo(object? x) => compareTo(x as Country);
        private int compareTo(Country? c) => Name.CompareTo(c?.Name);
    }
}
