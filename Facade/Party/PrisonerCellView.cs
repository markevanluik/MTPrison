using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade.Party {
    public class PrisonerCellView : NamedView {
        [Required, DisplayName("Prisoner")] public string PrisonerId { get; set; } = string.Empty;
        [Required, DisplayName("Cell")] public string CellId { get; set; } = string.Empty;

        [DisplayName("Interests")] public new string? Code { get; set; }
        [DisplayName("Put a name")] public new string? Name { get; set; }
        [DisplayName("Put a 2nd name"), Required] public new string? NativeName { get; set; }
    }
    public sealed class PrisonerCellViewFactory : BaseViewFactory<PrisonerCellView, PrisonerCell, PrisonerCellData> {
        protected override PrisonerCell toEntity(PrisonerCellData d) => new(d);
    }
}
