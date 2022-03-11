using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Pages {
    public class CellsPage : BasePage<CellView, Cell, ICellsRepo> {
        public CellsPage(ICellsRepo r) : base(r) { }
        protected override Cell toObject(CellView? item) => new CellViewFactory().Create(item);
        protected override CellView toView(Cell? entity) => new CellViewFactory().Create(entity);
    }
}
