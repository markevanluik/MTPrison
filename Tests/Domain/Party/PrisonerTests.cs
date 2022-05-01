using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class IPrisonersRepoTests : TypeTests { }
    [TestClass] public class PrisonerTests : SealedClassTests<Prisoner, UniqueEntity<PrisonerData>> {
        protected override Prisoner createObj() => new(GetRandom.Value<PrisonerData>());
        [TestMethod] public void FirstNameTest() => isReadOnly(obj.Data.FirstName);
        [TestMethod] public void LastNameTest() => isReadOnly(obj.Data.LastName);
        [TestMethod] public void OffenseTest() => isReadOnly(obj.Data.Offense);
        [TestMethod] public void DoBTest() => isReadOnly(obj.Data.DoB);
        [TestMethod] public void DateOfReleaseTest() => isReadOnly(obj.Data.DateOfRelease);
        [TestMethod] public void DateOfImprisonmentTest() => isReadOnly(obj.Data.DateOfImprisonment);
        [TestMethod] public void FullNameTest() => areEqual($"{obj.Data.FirstName} {obj.Data.LastName}", obj.FullName());

        [TestMethod] public void PrisonerCellsTest()
            => itemsTest<IPrisonerCellsRepo, PrisonerCell, PrisonerCellData>(
            d => d.PrisonerId = obj.Id, d => new PrisonerCell(d), () => obj.PrisonerCells);
        [TestMethod] public void CellsTest() => relatedItemsTest<ICellsRepo, PrisonerCell, Cell, CellData>
            (PrisonerCellsTest, () => obj.PrisonerCells, () => obj.Cells,
            x => x.CellId, d => new Cell(d), c => c?.Data, x => x?.Cell?.Data);
    }
}
