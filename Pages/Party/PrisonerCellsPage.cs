using Microsoft.AspNetCore.Mvc.Rendering;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Pages.Party {
    public sealed class PrisonerCellsPage : PagedPage<PrisonerCellView, PrisonerCell, IPrisonerCellsRepo> {
        private readonly IPrisonersRepo prisoners;
        private readonly ICellsRepo cells;

        public PrisonerCellsPage(IPrisonerCellsRepo r, IPrisonersRepo pr, ICellsRepo ce) : base(r) {
            prisoners = pr;
            cells = ce;
        }
        protected override PrisonerCell toObject(PrisonerCellView? item) => new PrisonerCellViewFactory().Create(item);
        protected override PrisonerCellView toView(PrisonerCell? entity) => new PrisonerCellViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(PrisonerCellView.PrisonerId),
            nameof(PrisonerCellView.CellId),
            nameof(PrisonerCellView.Code),
            nameof(PrisonerCellView.Name),
            nameof(PrisonerCellView.NativeName)
        };
        public IEnumerable<SelectListItem> UniquePrisoners {
            get {
                var ids = repo.GetAll().Select(x => x.PrisonerId);
                Prisoner? p = new();
                if (Item is not null) p = prisoners?.Get(Item.PrisonerId);
                var l = prisoners?
                    .GetAll()
                    .Select(x => new SelectListItem(x?.FullName, x?.Id, false, x?.Id != p?.Id && ids.Contains(x?.Id))) ?? new List<SelectListItem>();
                return l;
            }
        }
        // removes greyed_out prisoners from DropDownList, optional_for: @_EditPrisonerCell
        public IEnumerable<SelectListItem> RemoveGreyedOutPrisoners => UniquePrisoners.Where(x => !x.Disabled);
        public IEnumerable<SelectListItem> Cells
            => cells?.GetAll()?
            .Select(x => new SelectListItem(x.CellNumber.ToString(), x.Id)) ?? new List<SelectListItem>();
        public string PrisonerName(string? prisonerId = null)
            => UniquePrisoners?.FirstOrDefault(x => x.Value == (prisonerId ?? string.Empty))?.Text ?? $"No {nameof(Prisoner)}";
        public string CellName(string? cellId = null)
            => Cells?.FirstOrDefault(x => x.Value == (cellId ?? string.Empty))?.Text ?? $"No {nameof(Cell)}";

        public override object? GetValue(string name, PrisonerCellView v) {
            var r = base.GetValue(name, v);
            return name == nameof(v.PrisonerId) ? PrisonerName(r as string)
                 : name == nameof(v.CellId) ? CellName(r as string)
                 : r;
        }
    }
}
