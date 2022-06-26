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
                string? id = "";
                if (Item is not null) id = repo?.Get(Item.Id).Id;
                var l = repo?
                    .GetAll(x => x.CellNumber)
                    .Select(x => new SelectListItem(x.CellNumber.ToString(), x.CellNumber.ToString(), false, x.Id != id)) ?? new List<SelectListItem>();
                var last = 0;
                if (l.Any()) last = Convert.ToInt32(l.Max(x => int.Parse(x.Value)));
                for (int i = 1; i <= last; i++) {
                    if (l.Any(x => x.Value == i.ToString())) continue;
                    var unused = new SelectListItem { Value = i.ToString(), Text = i.ToString() };
                    l = l.Append(unused);
                }
                var plusOne = new SelectListItem { Value = (last + 1).ToString(), Text = (last + 1).ToString() };
                l = l.Append(plusOne);
                return l.Where(x => !x.Disabled);
            }
        }

        public IEnumerable<SelectListItem> Types => Enum.GetValues<CellType>()
            .Select(t => new SelectListItem(t.Description(), t.ToString())) ?? new List<SelectListItem>();
        public string CellTypeDescription(CellType? t) => (t ?? CellType.Standard).Description();

        public override object? GetValue(string name, CellView v) {
            var r = base.GetValue(name, v);
            return name == nameof(v.Type) ? CellTypeDescription((CellType?)r) : r;
        }
        public Lazy<List<Prisoner?>> Prisoners => toObject(Item).Prisoners;
    }
}
