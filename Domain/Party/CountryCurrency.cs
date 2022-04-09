using MTPrison.Data.Party;

namespace MTPrison.Domain.Party {
    public interface ICountryCurrenciesRepo : IRepo<CountryCurrency> { }
    public class CountryCurrency : NamedEntity<CountryCurrencyData> {
        // constructors
        public CountryCurrency() : this(new()) { }
        public CountryCurrency(CountryCurrencyData d) : base(d) { }
        //
        public string CountryId => getValue(Data?.CountryId);
        public string CurrencyId => getValue(Data?.CurrencyId);

        //Later
        //public Country? Country => GetRepo.Instance<ICountriesRepo>()?.Get(CountryId);
        //public Currency? Currency => GetRepo.Instance<ICurrenciesRepo>()?.Get(CurrencyId);
    }
}
