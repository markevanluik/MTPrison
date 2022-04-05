using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public class PrisonersRepo : Repo<Prisoner, PrisonerData>, IPrisonersRepo {
        public PrisonersRepo(PrisonDb? db) : base(db, db?.Prisoners) { }
        protected override Prisoner toDomain(PrisonerData d) => new(d);
        internal override IQueryable<PrisonerData> addFilter(IQueryable<PrisonerData> query) {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return query;
            return query.Where(
                x => x.FirstName.ToString().Contains(y)
                  || x.LastName.ToString().Contains(y)
                  || x.Offense.Contains(y));
        }
    }
}
