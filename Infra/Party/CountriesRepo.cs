using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public class CountriesRepo : Repo<Country, CountryData>, ICountriesRepo {
        public CountriesRepo(PrisonDb? db) : base(db, db?.Countries) { }
        protected override Country toDomain(CountryData d) => new(d);
    }
}
