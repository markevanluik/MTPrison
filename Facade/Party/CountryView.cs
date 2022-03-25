using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade.Party {
    public class CountryView : BaseView {
        [Display(Name = "Code")][MaxLength(3)][Required] public string Code { get; set; }
        [Display(Name = "Name")][Required] public string? Name { get; set; }
        [Display(Name = "Native Name")][Required] public string? NativeName { get; set; }
    }
    public sealed class CountryViewFactory : BaseViewFactory<CountryView, Country, CountryData> {
        protected override Country toEntity(CountryData d) => new(d);

    }
}
