using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public sealed class PrisonersRepo : Repo<Prisoner, PrisonerData>, IPrisonersRepo {
        public PrisonersRepo(PrisonDb? db) : base(db, db?.Prisoners) { }
        protected internal override Prisoner toDomain(PrisonerData d) => new(d);
        internal override IQueryable<PrisonerData> addFilter(IQueryable<PrisonerData> query) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? query : query.Where(
                x => x.Id.Contains(y)
                  || x.FirstName.Contains(y)
                  || x.LastName.Contains(y)
                  || x.Offense.Contains(y)
                  || x.DoB.ToString().Contains(y)
                  || x.DateOfRelease.ToString().Contains(y)
                  || x.DateOfImprisonment.ToString().Contains(y));
        }
    }
}
