using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade {
    public abstract class IsoCommonView : CommonView {
        [Required, MaxLength(3), Display(Name = "ISO 3-character code")] public new string? Code { get; set; }
        [Required, Display(Name = "English name")] public new string? Name { get; set; }
        [Required, Display(Name = "Native name")] public new string? NativeName { get; set; }
    }
}
