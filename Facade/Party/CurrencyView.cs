using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade.Party {
    public class CurrencyView : BaseView {
        [Display(Name = "Code")] [MaxLength(3)] [Required] public string Code { get; set; }
        [Display(Name = "Name")] [Required] public string? Name { get; set; }
        [Display(Name = "Native Name")] [Required] public string? NativeName { get; set; }
    }
    public sealed class CurrencyViewFactory : BaseViewFactory<CurrencyView, Currency, CurrencyData> {
        protected override Currency toEntity(CurrencyData d) => new(d);

    }
}
