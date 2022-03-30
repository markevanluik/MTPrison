using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade {
    public abstract class IsoCommonView : CommonView {
        // basically this class is not needed, cause country/currency both have ISO-s (ISO three-letter and ISO three-character),
        // and right now both are using "Code" for display anyway.. so for now this class has no reference
        [Required, MaxLength(3), Display(Name = "ISO 3-character code")] public new string? Code { get; set; }
        [Required, Display(Name = "English name")] public new string? Name { get; set; }
        [Required, Display(Name = "Native name")] public new string? NativeName { get; set; }
    }
}
