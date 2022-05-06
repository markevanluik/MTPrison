using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Infra;
using MTPrison.Infra.Initializers;

namespace MTPrison.Tests.Infra.Initializers {
    [TestClass] public class CellsInitializerTests : SealedBaseTests<CellsInitializer, BaseInitializer<CellData>> {
        protected override CellsInitializer createObj() {
            var db = GetRepo.Instance<PrisonDb>();
            return new CellsInitializer(db);
        }
    }
}
