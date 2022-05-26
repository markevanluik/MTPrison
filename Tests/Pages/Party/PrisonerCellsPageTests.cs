using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;
using MTPrison.Pages;
using MTPrison.Pages.Party;
using MTPrison.Aids;
using MTPrison.Data.Party;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MTPrison.Tests.Pages.Party {
    [TestClass] public class PrisonerCellsPageTests : SealedBaseTests<PrisonerCellsPage, PagedPage<PrisonerCellView, PrisonerCell, IPrisonerCellsRepo>> {
        private readonly IPrisonerCellsRepo? r = GetRepo.Instance<IPrisonerCellsRepo>();
        private readonly IPrisonersRepo? pr = GetRepo.Instance<IPrisonersRepo>();
        private readonly ICellsRepo? ce = GetRepo.Instance<ICellsRepo>();
        private PrisonerCell? pc;
        private Prisoner? p;
        private Cell? c;
        private PrisonerCellView? v;
        protected override PrisonerCellsPage createObj() {
            isNotNull(r); isNotNull(pr); isNotNull(ce);
            return new PrisonerCellsPage(r, pr, ce);
        }
        [TestInitialize] public void Init() {
            pc = new PrisonerCell(GetRandom.Value<PrisonerCellData>());
            p = new Prisoner(GetRandom.Value<PrisonerData>());
            c = new Cell(GetRandom.Value<CellData>());
            v = new PrisonerCellViewFactory().Create(pc);
            r?.Add(pc);
            pr?.Add(p);
            ce?.Add(c);
        }
        [TestMethod] public void IndexColumnsTest() => isReadOnly<string[]>();
        [TestMethod] public void UniquePrisonersTest() => isReadOnly<SelectListItem>();
        [TestMethod] public void CellsTest() => isReadOnly<SelectListItem>();
        [TestMethod] public void PrisonerNameTest() {
            isNotNull(p);
            var result = obj.PrisonerName(p.Id);
            areEqual(p.FullName, result);
            result = obj.PrisonerName("");
            areEqual($"No {nameof(Prisoner)}", result);
            result = obj.PrisonerName(null);
            areEqual($"No {nameof(Prisoner)}", result);
        }
        [TestMethod] public void CellNameTest() {
            isNotNull(c);
            var result = obj.CellName(c.Id);
            areEqual(c.CellNumber.ToString(), result);
            result = obj.CellName("");
            areEqual($"No {nameof(Cell)}", result);
            result = obj.CellName(null);
            areEqual($"No {nameof(Cell)}", result);
        }
        [TestMethod] public void GetValueTest() {
            isNotNull(pc);
            isNotNull(v);
            var result = obj.GetValue(nameof(pc.Id), v);
            areEqual(pc.Id, result);
            result = obj.GetValue(nameof(pc.PrisonerId), v);
            areEqual($"No {nameof(Prisoner)}", result);
        }
    }
}
