using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade {
    public abstract class IsoNamedView : NamedView {
        [Required, MaxLength(3), DisplayName("ISO 3-letter")] public new string? Code { get; set; }
        [Required, DisplayName("English name")] public new string? Name { get; set; }
        [Required, DisplayName("Native name")] public new string? NativeName { get; set; }
    }
}
