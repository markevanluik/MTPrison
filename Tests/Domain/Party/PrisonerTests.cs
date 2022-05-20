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
        [TestMethod] public void SSNTest() => isReadOnly(obj.Data.SSN);
        [TestMethod] public void CountryTest() => isReadOnly(obj.Data.Country);
        [TestMethod] public void OffenseTest() => isReadOnly(obj.Data.Offense);
        [TestMethod] public void DateOfImprisonmentTest() => isReadOnly(obj.Data.DateOfImprisonment);
        [TestMethod] public void DateOfReleaseTest() => isReadOnly(obj.Data.DateOfRelease);
        [TestMethod] public void FullNameTest() => areEqual($"{obj.Data.FirstName} {obj.Data.LastName}", obj.FullName);
        [TestMethod] public void CntryTest() => itemTest<ICountriesRepo, Country, CountryData>(
            obj.Country, d => new Country(d), () => obj.Cntry);
        [TestMethod] public void PrisonerCellsTest()
            => itemsTest<IPrisonerCellsRepo, PrisonerCell, PrisonerCellData>(
            d => d.PrisonerId = obj.Id, d => new PrisonerCell(d), () => obj.PrisonerCells.Value);
        [TestMethod] public void CellsTest() => relatedItemsTest<ICellsRepo, PrisonerCell, Cell, CellData>
            (PrisonerCellsTest, () => obj.PrisonerCells.Value, () => obj.Cells.Value,
            x => x.CellId, d => new Cell(d), c => c?.Data, x => x?.Cell?.Data);
    }
}
