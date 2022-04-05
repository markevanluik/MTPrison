using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public class CountriesRepo : Repo<Country, CountryData>, ICountriesRepo {
        public CountriesRepo(PrisonDb? db) : base(db, db?.Countries) { }
        protected override Country toDomain(CountryData d) => new(d);
        internal override IQueryable<CountryData> addFilter(IQueryable<CountryData> query) {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return query;
            return query.Where(
                x => x.Code.Contains(y)
                  || x.Name.Contains(y)
                  || x.NativeName.Contains(y));
        }
    }
}
