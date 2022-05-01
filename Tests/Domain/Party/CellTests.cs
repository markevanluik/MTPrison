using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class ICellsRepoTests : TypeTests { }
    [TestClass] public class CellTests : SealedClassTests<Cell, UniqueEntity<CellData>> {
        protected override Cell createObj() => new(GetRandom.Value<CellData>());
        [TestMethod] public void CellNumberTest() => isReadOnly(obj.Data.CellNumber);
        [TestMethod] public void CapacityTest() => isReadOnly(obj.Data.Capacity);
        [TestMethod] public void TypeTest() => isReadOnly(obj.Data.Type);
        [TestMethod] public void SectionTest() => isReadOnly(obj.Data.Section);
    }
}
