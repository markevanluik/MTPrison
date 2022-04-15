using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using System;

namespace MTPrison.Tests.Data.Party {
    [TestClass] public class CellDataTests : SealedClassTests<CellData> {
        [TestMethod] public void CellNumberTest() => isProperty<int>();
        [TestMethod] public void CapacityTest() => isProperty<int>();
        [TestMethod] public void TypeTest() => isProperty<CellType?>();
        [TestMethod] public void SectionTest() => isProperty<string?>();
        [TestMethod] public void CountryIdTest() => isProperty<string?>();
        [TestMethod] public void InspectionTest() => isProperty<DateTime?>();
    }

    [TestClass] public class CellTypeTests : IsTypeTested {
        [TestMethod] public void DeluxeTest() => doTest(CellType.Deluxe, 0, "Deluxe");
        [TestMethod] public void DuoTest() => doTest(CellType.Duo, 1, "Duo");
        [TestMethod] public void SolitaryTest() => doTest(CellType.Solitary, 2, "Solitary");
        [TestMethod] public void NotApplicableTest() => doTest(CellType.NotApplicable, 9, "Not applicable");

        private static void doTest(CellType type, int value, string description) {
            areEqual(value, (int)type);
            areEqual(description, type.Description());
        }
    }
}
