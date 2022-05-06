using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using MTPrison.Infra;

namespace MTPrison.Tests.Infra {
    [TestClass] public class FilteredRepoTests : AbstractClassTests<FilteredRepo<Prisoner, PrisonerData>, CrudRepo<Prisoner, PrisonerData>> {
        private class testClass : FilteredRepo<Prisoner, PrisonerData> {
            public testClass(DbContext? c, DbSet<PrisonerData>? s) : base(c, s) { }
            protected internal override Prisoner toDomain(PrisonerData d) => new(d);
        }
        protected override FilteredRepo<Prisoner, PrisonerData> createObj() {
            var db = GetRepo.Instance<PrisonDb>();
            var set = db?.Prisoners;
            return new testClass(db, set);
        }

        [TestMethod] public void CurrentFilterTest() => isProperty<string>();

        [DataRow(true)]
        [DataRow(false)]
        [TestMethod] public void CreateSqlTest(bool hasCurrentFilter) {
            obj.CurrentFilter = hasCurrentFilter ? GetRandom.String() : null;
            var q1 = obj.createSql();
            var q2 = obj.addFilter(q1);
            areEqual(q1, q2);
            var s = q1.Expression.ToString();
            isTrue(s.EndsWith(".Select(s => s)"));
        }
    }
}
