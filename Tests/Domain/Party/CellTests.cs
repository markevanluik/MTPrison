using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Domain.Party;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class CellTests : BaseTests<Cell> {
        [TestMethod] public void IdTest() => isInconclusive();
        [TestMethod] public void CellNumberTest() => isInconclusive();
        [TestMethod] public void CapacityTest() => isInconclusive();
        [TestMethod] public void TypeTest() => isInconclusive();
        [TestMethod] public void SectionTest() => isInconclusive();

    }
}
