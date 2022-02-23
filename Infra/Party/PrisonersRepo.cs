using Microsoft.EntityFrameworkCore;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTPrison.Infra.Party {
    public class PrisonersRepo : Repo<Prisoner, PrisonerData>, IPrisonersRepo {
        public PrisonersRepo(DbContext c, DbSet<PrisonerData> s) : base(c, s) { }
        protected override Prisoner toDomain(PrisonerData d) => new Prisoner(d);
    }
}
