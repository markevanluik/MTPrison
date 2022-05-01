using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade.Party {
    public sealed class CellView : UniqueView {
        [Required, DisplayName("Cell Number"), Range(1, 10000)] public int CellNumber { get; set; }
        [Required, DisplayName("Section")] public string? Section { get; set; }
        [DisplayName("Capacity"), Range(1, 1000)] public int Capacity { get; set; }
        [Required, DisplayName("Type")] public CellType? Type { get; set; }
    }
    public sealed class CellViewFactory : BaseViewFactory<CellView, Cell, CellData> {
        protected override Cell toEntity(CellData d) => new(d);
        public override Cell Create(CellView? v) {
            v ??= new CellView();
            v.Type ??= CellType.Standard;
            return base.Create(v);
        }
        public override CellView Create(Cell? e) {
            var v = base.Create(e);
            v.Type = e?.Type;
            return v;
        }
    }
}
