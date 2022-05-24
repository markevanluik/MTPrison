using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade.Party {
    public sealed class PrisonerCellView : NamedView {
        [Required, DisplayName("Prisoner")] public string PrisonerId { get; set; } = string.Empty;
        [Required, DisplayName("Cell")] public string CellId { get; set; } = string.Empty;

        [DisplayName("Interests")] public new string? Code { get; set; }
        [DisplayName("Date Of Imprisonment")] public new string? Name { get; set; }
        [DisplayName("Date Of Release")] public new string? NativeName { get; set; }
    }
    public sealed class PrisonerCellViewFactory : BaseViewFactory<PrisonerCellView, PrisonerCell, PrisonerCellData> {
        protected override PrisonerCell toEntity(PrisonerCellData d) => new(d);
        public override PrisonerCell Create(PrisonerCellView? v) {
            v ??= new PrisonerCellView();
            var pc = base.Create(v);
            var d = new PrisonerCellData();
            if (v is null) return toEntity(d);
            v.Name = pc?.Prisoner?.DateOfImprisonment.ToShortDateString() ?? string.Empty;
            v.NativeName = pc?.Prisoner?.DateOfRelease.ToShortDateString() ?? string.Empty;
            copy(v, d);
            return toEntity(d);
        }
    }
}
