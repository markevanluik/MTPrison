using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade.Party {
    public class CountryCurrencyView : IsoNamedView {
        [Required, DisplayName("Country")] public string CountryId { get; set; } = string.Empty;
        [Required, DisplayName("Currency")] public string CurrencyId { get; set; } = string.Empty;

        [DisplayName("Symbol")] public new string? Name { get; set; }
    }
    public sealed class CountryCurrencyViewFactory : BaseViewFactory<CountryCurrencyView, CountryCurrency, CountryCurrencyData> {
        protected override CountryCurrency toEntity(CountryCurrencyData d) => new(d);
    }
}
