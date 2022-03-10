using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTPrison.Tests.Infra {
    [TestClass] public class PrisonDbTests : IsTypeTested {
        [TestMethod] public void PrisonersTest() => isInconclusive();
        [TestMethod] public void CellsTest() => isInconclusive();
        [TestMethod] public void InitializeTablesTest() => isInconclusive();
    }
}
