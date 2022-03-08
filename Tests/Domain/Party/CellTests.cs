using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Domain.Party;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class CellTests : BaseTests<Cell> {
        [TestMethod] public void IdTest() => isProperty<string?>();
        [TestMethod] public void CellNumberTest() => isProperty<int>();
        [TestMethod] public void CapacityTest() => isProperty<int>();
        [TestMethod] public void TypeTest() => isProperty<string?>();
        [TestMethod] public void SectionTest() => isProperty<string?>();
    }
}
