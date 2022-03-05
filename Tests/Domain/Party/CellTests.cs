using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Domain.Party;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class CellTests : BaseTests<Cell> {
        private readonly Cell cell = new() { };
        [TestMethod] public void IdTest() {
            Assert.AreEqual("Undefined", cell.Id);
        }
        [TestMethod] public void CellNumberTest() {
            Assert.AreEqual(0, cell.CellNumber);
        }
        [TestMethod] public void CapacityTest() {
            Assert.AreEqual(0, cell.Capacity);
        }
        [TestMethod] public void TypeTest() {
            Assert.AreEqual("Undefined", cell.Type);
        }
        [TestMethod] public void SectionTest() {
            Assert.AreEqual("Undefined", cell.Section);
        }
    }
}
