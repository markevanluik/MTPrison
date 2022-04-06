using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Pages.Party {
    public class CellsPage : PagedPage<CellView, Cell, ICellsRepo> {
        public CellsPage(ICellsRepo r) : base(r) { }
        protected override Cell toObject(CellView? item) => new CellViewFactory().Create(item);
        protected override CellView toView(Cell? entity) => new CellViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CellView.CellNumber),
            nameof(CellView.Capacity),
            nameof(CellView.Type),
            nameof(CellView.Section)
        };
    }
}
