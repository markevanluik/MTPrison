using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public class CurrenciesRepo : Repo<Currency, CurrencyData>, ICurrenciesRepo {
        public CurrenciesRepo(PrisonDb? db) : base(db, db?.Currencies) { }
        protected override Currency toDomain(CurrencyData d) => new(d);

        internal override IQueryable<CurrencyData> addFilter(IQueryable<CurrencyData> query) {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return query;
            return query.Where(
                x => x.Code.Contains(y)
                  || x.Name.Contains(y)
                  || x.NativeName.Contains(y));
        }
    }
}
