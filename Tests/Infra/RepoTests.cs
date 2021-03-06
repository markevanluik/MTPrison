using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain;
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
        protected override PagedRepo<Prisoner, PrisonerData> createObj() {
            var db = GetRepo.Instance<PrisonDb>();
            var set = db?.Prisoners;
            return new testClass(db, set);
        }

        [TestMethod] public void PageIndexTest() => isProperty(obj.PageIndex);
        [TestMethod] public void TotalPagesTest() => isReadOnly(obj.TotalPages);
        [TestMethod] public void HasNextPageTest() => isReadOnly(obj.HasNextPage);
        [TestMethod] public void HasPreviousPageTest() => isReadOnly(obj.HasPreviousPage);
        [TestMethod] public void PageSizeTest() => isProperty(obj.PageSize);
    }
}
