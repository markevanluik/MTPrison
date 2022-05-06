using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using MTPrison.Infra;
using MTPrison.Infra.Party;

namespace MTPrison.Tests.Infra.Party {
    [TestClass] public class PrisonerCellsRepoTests : SealedRepoTests<PrisonerCellsRepo, Repo<PrisonerCell, PrisonerCellData>, PrisonerCell, PrisonerCellData> {
        protected override PrisonerCellsRepo createObj() => new(GetRepo.Instance<PrisonDb>());
        protected override object? getSet(PrisonDb db) => db.PrisonerCells;
    }
}
