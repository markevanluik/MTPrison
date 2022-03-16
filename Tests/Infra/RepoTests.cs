using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Infra;

namespace MTPrison.Tests.Infra {
    [TestClass] public class RepoTests : AbstractClassTests {
        [TestMethod] public void AddTest() => isInconclusive();
        [TestMethod] public void GetTest() => isInconclusive();
        [TestMethod] public void UpdateTest() => isInconclusive();
        [TestMethod] public void DeleteTest() => isInconclusive();
        [TestMethod] public void AddAsyncTest() => isInconclusive();
        [TestMethod] public void GetAsyncTest() => isInconclusive();
        [TestMethod] public void UpdateAsyncTest() => isInconclusive();
        [TestMethod] public void DeleteAsyncTest() => isInconclusive();

        private class TestClass : Repo<Prisoner, PrisonerData> {
            public TestClass(DbContext? c, DbSet<PrisonerData>? s) : base(c, s) { }
            protected override Prisoner toDomain(PrisonerData d) => new(d);
        }
        protected override object createObject() => new TestClass(null, null);

    }
}
