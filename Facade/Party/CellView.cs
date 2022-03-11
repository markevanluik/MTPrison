using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade.Party {
    public class CellView : BaseView {
        [Display(Name = "Cell Number")] [Range(1, 10000)] public int CellNumber { get; set; }
        [Display(Name = "Capacity")] [Range(1, 1000)] public int Capacity { get; set; }
        [Display(Name = "Type")] [Required] public string? Type { get; set; }
        [Display(Name = "Section")] [Required] public string? Section { get; set; }

        //public List<Prisoner> Occupants { get; set; }

    }
    public sealed class CellViewFactory : BaseViewFactory<CellView, Cell, CellData> {
        protected override Cell toEntity(CellData d) => new(d);

    }
}
