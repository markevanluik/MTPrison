using MTPrison.Data.Party;

namespace MTPrison.Domain.Party {
    public interface ICurrenciesRepo : IRepo<Currency> { }
    public sealed class Currency : NamedEntity<CurrencyData> {
        public Currency() : this(new()) { }
        public Currency(CurrencyData d) : base(d) { }

        public Lazy<List<CountryCurrency>> CountryCurrencies {
            get {
                var l = GetRepo.Instance<ICountryCurrenciesRepo>()?
                    .GetAll(x => x.CurrencyId)?
                    .Where(x => x.CurrencyId == Id)?
                    .ToList() ?? new List<CountryCurrency>();
                return new Lazy<List<CountryCurrency>>(l);
            }
        }
        public Lazy<List<Country?>> Countries {
            get {
                var l = CountryCurrencies.Value
                    .Select(x => x.Country)
                    .ToList() ?? new List<Country?>();
                return new Lazy<List<Country?>>(l);
            }
        }
    }
}
