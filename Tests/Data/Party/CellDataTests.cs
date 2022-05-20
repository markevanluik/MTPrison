using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data;
using MTPrison.Data.Party;

namespace MTPrison.Tests.Data.Party {
    [TestClass] public class CellDataTests : SealedClassTests<CellData, UniqueData> {
        [TestMethod] public void CellNumberTest() => isProperty<int>();
        [TestMethod] public void CapacityTest() => isProperty<int>();
        [TestMethod] public void TypeTest() => isProperty<CellType>();
        [TestMethod] public void SectionTest() => isProperty<string>();
    }

    [TestClass] public class CellTypeTests : TypeTests {
        [TestMethod] public void SolitaryTest() => doTest(CellType.Solitary, 0, "Solitary");
        [TestMethod] public void DuoTest() => doTest(CellType.Duo, 1, "Duo");
        [TestMethod] public void QuadTest() => doTest(CellType.Quad, 2, "Quad");
        [TestMethod] public void DeluxeTest() => doTest(CellType.Deluxe, 3, "Deluxe");
        [TestMethod] public void StandardTest() => doTest(CellType.Standard, 9, "Standard");

        private static void doTest(CellType type, int value, string description) {
            areEqual(value, (int)type);
            areEqual(description, type.Description());
        }
    }
}
