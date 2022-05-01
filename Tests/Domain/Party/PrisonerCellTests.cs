using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class IPrisonerCellsRepoTests : TypeTests { }
    [TestClass] public class PrisonerCellTests : SealedClassTests<PrisonerCell, NamedEntity<PrisonerCellData>> {
        protected override PrisonerCell createObj() => new(GetRandom.Value<PrisonerCellData>());
        [TestMethod] public void PrisonerIdTest() => isReadOnly(obj.Data.PrisonerId);
        [TestMethod] public void CellIdTest() => isReadOnly(obj.Data.CellId);

        [TestMethod] public void PrisonerTest() => itemTest<IPrisonersRepo, Prisoner, PrisonerData>(
            obj.PrisonerId, d => new Prisoner(d), () => obj.Prisoner);
        [TestMethod] public void CellTest() => itemTest<ICellsRepo, Cell, CellData>(
            obj.CellId, d => new Cell(d), () => obj.Cell);
    }
}
