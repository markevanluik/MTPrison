using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Infra;

namespace MTPrison.Tests.Infra {
    [TestClass] public class RepoTests : AbstractClassTests<Repo<Prisoner, PrisonerData>, PagedRepo<Prisoner, PrisonerData>> {
        private class testClass : Repo<Prisoner, PrisonerData> {
            public testClass(DbContext? c, DbSet<PrisonerData>? s) : base(c, s) { }
            protected internal override Prisoner toDomain(PrisonerData d) => new(d);
        }
        protected override Repo<Prisoner, PrisonerData> createObj() => new testClass(null, null);
    }
    // unfinished
    [TestClass] public class PagedRepoTests : AbstractClassTests<PagedRepo<Prisoner, PrisonerData>, OrderedRepo<Prisoner, PrisonerData>> {
        private class testClass : PagedRepo<Prisoner, PrisonerData> {
            public testClass(DbContext? c, DbSet<PrisonerData>? s) : base(c, s) { }
            protected internal override Prisoner toDomain(PrisonerData d) => new(d);
        }
        protected override PagedRepo<Prisoner, PrisonerData> createObj() => new testClass(null, null);
    }
}
