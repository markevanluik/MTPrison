using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public sealed class CurrenciesRepo : Repo<Currency, CurrencyData>, ICurrenciesRepo {
        public CurrenciesRepo(PrisonDb? db) : base(db, db?.Currencies) { }
        protected internal override Currency toDomain(CurrencyData d) => new(d);
        internal override IQueryable<CurrencyData> addFilter(IQueryable<CurrencyData> query) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? query : query.Where(
                x => x.Id.Contains(y)
                  || x.Code.Contains(y)
                  || x.Name.Contains(y)
                  || x.NativeName.Contains(y));
        }
    }
}
