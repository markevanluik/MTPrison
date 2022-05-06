using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public sealed class CountriesRepo : Repo<Country, CountryData>, ICountriesRepo {
        public CountriesRepo(PrisonDb? db) : base(db, db?.Countries) { }
        protected internal override Country toDomain(CountryData d) => new(d);
        internal override IQueryable<CountryData> addFilter(IQueryable<CountryData> query) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? query : query.Where(
                x => x.Id.Contains(y)
                  || x.Code.Contains(y)
                  || x.Name.Contains(y)
                  || x.NativeName.Contains(y));
        }
    }
}
