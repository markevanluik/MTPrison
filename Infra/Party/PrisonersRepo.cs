using Microsoft.EntityFrameworkCore;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public class PrisonersRepo : Repo<Prisoner, PrisonerData>, IPrisonersRepo {
        public PrisonersRepo(DbContext c, DbSet<PrisonerData> s) : base(c, s) { }
        protected override Prisoner toDomain(PrisonerData d) => new Prisoner(d);
    }
}
