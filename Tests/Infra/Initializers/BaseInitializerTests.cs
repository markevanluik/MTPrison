using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Infra;
using MTPrison.Infra.Initializers;
using System.Collections.Generic;

namespace MTPrison.Tests.Infra.Initializers {
    [TestClass] public class BaseInitializerTests : AbstractClassTests<BaseInitializer<PrisonerData>, object> {

        private class testClass : BaseInitializer<PrisonerData> {
            public testClass(DbContext? c, DbSet<PrisonerData>? s) : base(c, s) { }
            protected override IEnumerable<PrisonerData> getEntities => throw new System.NotImplementedException();
        }
        protected override PrisonersInitializer createObj() {
            var db = GetRepo.Instance<PrisonDb>();
            return new PrisonersInitializer(db);
        }
    }
}
