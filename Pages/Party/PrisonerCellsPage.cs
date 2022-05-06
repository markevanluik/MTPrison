using Microsoft.AspNetCore.Mvc.Rendering;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Pages.Party {
    public class PrisonerCellsPage : PagedPage<PrisonerCellView, PrisonerCell, IPrisonerCellsRepo> {
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
        public IEnumerable<SelectListItem> Prisoners
            => prisoners?.GetAll()?
            .Select(x => new SelectListItem(x.FullName, x.Id)) ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Cells
            => cells?.GetAll()?
            .Select(x => new SelectListItem(x.CellNumber.ToString(), x.Id)) ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> UniqueCells
            => cells?.GetAll()?
            .GroupBy(t => t.CellNumber)
            .Select(f => f.FirstOrDefault())
            .Select(x => new SelectListItem(x?.CellNumber.ToString(), x?.Id)) ?? new List<SelectListItem>();
        public string PrisonerName(string? prisonerId = null)
            => Prisoners?.FirstOrDefault(x => x.Value == (prisonerId ?? string.Empty))?.Text ?? "Unspecified";
        public string CellName(string? cellId = null)
            => Cells?.FirstOrDefault(x => x.Value == (cellId ?? string.Empty))?.Text ?? "Unspecified";

        public override object? GetValue(string name, PrisonerCellView v) {
            var r = base.GetValue(name, v);
            return name == nameof(v.PrisonerId) ? PrisonerName(r as string)
                 : name == nameof(v.CellId) ? CellName(r as string)
                 : r;
        }
    }
}
