using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using MTPrison.Infra;

namespace MTPrison.Tests.Infra {
    [TestClass]
    public class OrderedRepoTests : AbstractClassTests<OrderedRepo<Prisoner, PrisonerData>, FilteredRepo<Prisoner, PrisonerData>> {
        private class testClass : OrderedRepo<Prisoner, PrisonerData> {
            public testClass(DbContext? c, DbSet<PrisonerData>? s) : base(c, s) { }
            protected internal override Prisoner toDomain(PrisonerData d) => new(d);
        }
        protected override OrderedRepo<Prisoner, PrisonerData> createObj() {
            var db = GetRepo.Instance<PrisonDb>();
            var set = db?.Prisoners;
            return new testClass(db, set);
        }

        [TestMethod] public void CurrentOrderTest() => isProperty<string>();
        [TestMethod] public void DescendingStringTest() => areEqual("_desc", testClass.DescendingString);

        [DataRow(null, true)]
        [DataRow(null, false)]
        [DataRow(nameof(Prisoner.Id), true)]
        [DataRow(nameof(Prisoner.Id), false)]
        [DataRow(nameof(Prisoner.FirstName), true)]
        [DataRow(nameof(Prisoner.FirstName), false)]
        [DataRow(nameof(Prisoner.LastName), true)]
        [DataRow(nameof(Prisoner.LastName), false)]
        [DataRow(nameof(Prisoner.DoB), true)]
        [DataRow(nameof(Prisoner.DoB), false)]
        [TestMethod] public void CreateSqlTest(string s, bool isDescending) {
            obj.CurrentOrder = (s is null) ? s : isDescending ? s + testClass.DescendingString : s;
            var q = obj.createSql();
            var actual = q.Expression.ToString();
            if (s is null) isTrue(actual.EndsWith(".Select(s => s)"));
            else if (isDescending) isTrue(actual.EndsWith(
                $".Select(s => s).OrderByDescending(x => Convert(x.{s}, Object))"));
            else isTrue(actual.EndsWith(
                $".Select(s => s).OrderBy(x => Convert(x.{s}, Object))"));
        }

        [DataRow(null, null)]
        [DataRow(false, false)]
        [DataRow(false, true)]
        [DataRow(true, false)]
        [DataRow(true, true)]
        [TestMethod] public void SortOrderTest(bool isDescending, bool isSame) {
            var s = GetRandom.String();
            var c = isSame ? s : GetRandom.String();
            obj.CurrentOrder = isDescending ? c + testClass.DescendingString : c;
            var actual = obj.SortOrder(s);
            var sDec = s + testClass.DescendingString;
            var expected = isSame ? (isDescending ? s : sDec) : sDec;
            areEqual(expected, actual);
        }
    }
}
