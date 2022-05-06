using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Infra;
using MTPrison.Infra.Initializers;

namespace MTPrison.Tests.Infra.Initializers {
    [TestClass] public class PrisonersInitializerTests : SealedBaseTests<PrisonersInitializer, BaseInitializer<PrisonerData>> {
        protected override PrisonersInitializer createObj() {
            var db = GetRepo.Instance<PrisonDb>();
            return new PrisonersInitializer(db);
        }
    }
}
