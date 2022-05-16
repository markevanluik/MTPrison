using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Infra;
using MTPrison.Infra.Initializers;
using System.Collections.Generic;

namespace MTPrison.Tests.Infra.Initializers {
    [TestClass] public class BaseInitializerTests : AbstractClassTests<BaseInitializer<PrisonerData>, object> {
        private PrisonDb? db;
        private DbSet<PrisonerData>? set;
        private class testClass : BaseInitializer<PrisonerData> {
            public testClass(DbContext? c, DbSet<PrisonerData>? s) : base(c, s) { }
            protected override IEnumerable<PrisonerData> getEntities {
                get {
                    isNotNull(set);
                    set.Add(GetRandom.Value<PrisonerData>());
                    return set;
                }
            }
        }
        protected override BaseInitializer<PrisonerData> createObj() {
            db = GetRepo.Instance<PrisonDb>();
            set = db?.Prisoners;
            return new testClass(db, set);
        }
        [TestMethod] public void InitTest() {
            isNotNull(obj.set);
            areEqual(obj.set.Local.Count, 0);
            obj.Init();
            areEqual(obj.set.Local.Count, 1);
        }
    }
}
