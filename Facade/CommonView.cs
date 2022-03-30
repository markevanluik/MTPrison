using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade {
    public abstract class CommonView : UniqueView {
        [Display(Name = "Code"), MaxLength(3), Required] public string? Code { get; set; }
        [Display(Name = "Name"), Required] public string? Name { get; set; }
        [Display(Name = "Native Name"), Required] public string? NativeName { get; set; }
    }
}
