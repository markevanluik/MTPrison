using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Infra;
using MTPrison.Infra.Initializers;

namespace MTPrison.Tests.Infra.Initializers {
    [TestClass] public class PrisonerCellsInitializerTests : SealedBaseTests<PrisonerCellsInitializer, BaseInitializer<PrisonerCellData>> {
        protected override PrisonerCellsInitializer createObj() {
            var db = GetRepo.Instance<PrisonDb>();
            return new PrisonerCellsInitializer(db);
        }
    }
}
