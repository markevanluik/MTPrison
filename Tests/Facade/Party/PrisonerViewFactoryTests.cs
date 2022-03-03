using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class PrisonerViewFactoryTests : BaseTests<PrisonerViewFactory> {
        [TestMethod] public void CreateTest() => isInconclusive();
    }
}
