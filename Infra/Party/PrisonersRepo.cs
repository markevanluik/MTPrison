using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public class PrisonersRepo : Repo<Prisoner, PrisonerData>, IPrisonersRepo {
        public PrisonersRepo(PrisonDb db) : base(db, db.Prisoners) { }
        protected override Prisoner toDomain(PrisonerData d) => new Prisoner(d);
    }
}
