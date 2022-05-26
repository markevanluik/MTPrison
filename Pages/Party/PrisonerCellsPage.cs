using Microsoft.AspNetCore.Mvc.Rendering;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;
using System.Linq;

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
                var pc = repo?
                    .GetAll(x => x.Id)
                    .Select(x => x.Prisoner);
                var p = prisoners?.GetAll()?
                    .GroupBy(g => g.FullName)
                    .Select(f => f.FirstOrDefault())
                    .Select(x => new SelectListItem(x?.FullName, x?.Id, true, pc.Any(z => z?.Id == x?.Id))) ?? new List<SelectListItem>();
                return p;
            }
        }
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
