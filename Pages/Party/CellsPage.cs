using Microsoft.AspNetCore.Mvc.Rendering;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Pages.Party {
    public sealed class CellsPage : PagedPage<CellView, Cell, ICellsRepo> {
        public CellsPage(ICellsRepo r) : base(r) { }
        protected override Cell toObject(CellView? item) => new CellViewFactory().Create(item);
        protected override CellView toView(Cell? entity) => new CellViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CellView.CellNumber),
            nameof(CellView.Section),
            nameof(CellView.Capacity),
            nameof(CellView.Type)
        };

        public IEnumerable<SelectListItem> Types => Enum.GetValues<CellType>()
            .Select(g => new SelectListItem(g.Description(), g.ToString())) ?? new List<SelectListItem>();

        public string CellTypeDescription(CellType? g) => (g ?? CellType.Standard).Description();

        public override object? GetValue(string name, CellView v) {
            var r = base.GetValue(name, v);
            return name == nameof(v.Type) ? CellTypeDescription((CellType?)r) : r;
        }

        public Lazy<List<Prisoner?>> Prisoners => toObject(Item).Prisoners;
    }
}
