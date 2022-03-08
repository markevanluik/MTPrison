using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Domain.Party;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class CellTests : BaseTests<Cell> {
        private readonly Cell cell = new();
        [TestMethod] public void IdTest() {
            areEqual("Undefined", cell.Id);
        }
        [TestMethod] public void CellNumberTest() {
            areEqual(0, cell.CellNumber);
        }
        [TestMethod] public void CapacityTest() {
            areEqual(0, cell.Capacity);
        }
        [TestMethod] public void TypeTest() {
            areEqual("Undefined", cell.Type);
        }
        [TestMethod] public void SectionTest() {
            areEqual("Undefined", cell.Section);
        }
    }
}
