using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class CellViewFactoryTests : BaseTests<CellViewFactory> {
        [TestMethod] public void CreateTest() => isInconclusive();
    }
}
