using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Domain.Party;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class ICellsRepoTests : IsTypeTested { }
    [TestClass] public class CellTests : SealedClassTests<Cell> {
        [TestMethod] public void IdTest() => isProperty<string?>(null, true);
        [TestMethod] public void CellNumberTest() => isProperty<int?>(null, true);
        [TestMethod] public void CapacityTest() => isProperty<int?>(null, true);
        [TestMethod] public void TypeTest() => isProperty<string?>(null, true);
        [TestMethod] public void SectionTest() => isProperty<string?>(null, true);
    }
}
