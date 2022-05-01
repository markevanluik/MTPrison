using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade {
    public abstract class NamedView : UniqueView {
        [DisplayName("Code"), MaxLength(3), Required] public string? Code { get; set; }
        [DisplayName("Name"), Required] public string? Name { get; set; }
        [DisplayName("Native name"), Required] public string? NativeName { get; set; }
    }
}
