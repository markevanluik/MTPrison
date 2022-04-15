using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public class CountryCurrenciesRepo : Repo<CountryCurrency, CountryCurrencyData>, ICountryCurrenciesRepo {
        public CountryCurrenciesRepo(PrisonDb? db) : base(db, db?.CountryCurrencies) { }
        protected override CountryCurrency toDomain(CountryCurrencyData d) => new(d);

        internal override IQueryable<CountryCurrencyData> addFilter(IQueryable<CountryCurrencyData> query) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? query : query.Where(
                x => x.Id.Contains(y)
                  || x.CountryName.Contains(y)
                  || x.CurrencyName.Contains(y)
                  || x.CountryId.Contains(y)
                  || x.CurrencyId.Contains(y)
                  || x.Code.Contains(y)
                  || x.Name.Contains(y)
                  || x.NativeName.Contains(y));
        }
    }
}
