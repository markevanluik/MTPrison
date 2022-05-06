using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using MTPrison.Infra;
using MTPrison.Infra.Party;

namespace MTPrison.Tests.Infra.Party {
    [TestClass] public class CellsRepoTests : SealedRepoTests<CellsRepo, Repo<Cell, CellData>, Cell, CellData> {
        protected override CellsRepo createObj() => new(GetRepo.Instance<PrisonDb>());
        protected override object? getSet(PrisonDb db) => db.Cells;
    }
}
