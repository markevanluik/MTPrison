using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Domain;
using MTPrison.Infra;
using MTPrison.Infra.Initializers;

namespace MTPrison.Tests.Infra.Initializers {
    [TestClass] public class PrisonDbInitializerTests : TypeTests {
        [TestMethod] public void InitTest() {
            var db = GetRepo.Instance<PrisonDb>();
            isNotNull(db?.Prisoners);
            areEqual(db.Prisoners.Local.Count, 0);
            PrisonDbInitializer.Init(db);
            areEqual(db.Prisoners.Local.Count, 4);

        }
    }
}
