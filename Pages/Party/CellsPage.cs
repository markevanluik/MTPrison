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
        public IEnumerable<SelectListItem> UniqueCells {
            get {
                Cell? s = new();
                if (Item is not null) s = repo?.Get(Item.Id);
                var l = repo?
                    .GetAll(x => x.CellNumber)
                    .Select(x => new SelectListItem(x.CellNumber.ToString(), x.CellNumber.ToString(), false, x.Id is not null && x.Id != s?.Id)) ?? new List<SelectListItem>();
                var val = Convert.ToInt32(l.Last().Value);
                var e = new SelectListItem {
                    Value = (val + 1).ToString(),
                    Text = (val + 1).ToString()
                };
                return l.Append(e);
            }
        }
        public string CellNr(string? cellNr = null)
            => UniqueCells?.FirstOrDefault(x => x.Value == (cellNr ?? string.Empty))?.Text ?? $"No {nameof(Cell)}";

        public IEnumerable<SelectListItem> Types => Enum.GetValues<CellType>()
            .Select(g => new SelectListItem(g.Description(), g.ToString())) ?? new List<SelectListItem>();
        public string CellTypeDescription(CellType? g) => (g ?? CellType.Standard).Description();

        public override object? GetValue(string name, CellView v) {
            var r = base.GetValue(name, v);
            return name == nameof(v.Type) ? CellTypeDescription((CellType?)r)
                 : name == nameof(v.CellNumber) ? CellNr(r?.ToString())
                 : r;
        }
        public Lazy<List<Prisoner?>> Prisoners => toObject(Item).Prisoners;
    }
}
