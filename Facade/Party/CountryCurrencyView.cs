using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade.Party {
    public class CountryCurrencyView : IsoNamedView {
        [Required] public string CountryId { get; set; } = string.Empty;
        [Required] public string CurrencyId { get; set; } = string.Empty;
        [DisplayName("Country")] public string? CountryName { get; set; } = string.Empty;
        [DisplayName("Currency")] public string? CurrencyName { get; set; } = string.Empty;
        [DisplayName("Symbol")] public new string? Name { get; set; }
    }
    public sealed class CountryCurrencyViewFactory : BaseViewFactory<CountryCurrencyView, CountryCurrency, CountryCurrencyData> {
        protected override CountryCurrency toEntity(CountryCurrencyData d) => new(d);
    }
}
