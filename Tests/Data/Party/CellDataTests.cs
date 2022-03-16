using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;

namespace MTPrison.Tests.Data.Party {
    [TestClass] public class CellDataTests : SealedClassTests<CellData> {
        [TestMethod] public void CellNumberTest() => isProperty<int>();
        [TestMethod] public void CapacityTest() => isProperty<int>();
        [TestMethod] public void TypeTest() => isProperty<string?>();
        [TestMethod] public void SectionTest() => isProperty<string?>();
    }
}
