using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade.Party {
    public sealed class CountryCurrencyView : IsoNamedView {
        [Required, DisplayName("Country Id")] public string CountryId { get; set; } = string.Empty;
        [Required, DisplayName("Currency Id")] public string CurrencyId { get; set; } = string.Empty;
        [DisplayName("Country")] public string? CountryName { get; set; } = string.Empty;
        [DisplayName("Currency")] public string? CurrencyName { get; set; } = string.Empty;
        [DisplayName("Symbol")] public new string? Name { get; set; }
    }
    public sealed class CountryCurrencyViewFactory : BaseViewFactory<CountryCurrencyView, CountryCurrency, CountryCurrencyData> {
        protected override CountryCurrency toEntity(CountryCurrencyData d) => new(d);

        //when creating new..names get name data
        public override CountryCurrency Create(CountryCurrencyView? v) {
            var c = base.Create(v);
            var d = new CountryCurrencyData();
            if (v is null) return toEntity(d);
            v.CountryName = c?.Country?.Name ?? string.Empty;
            v.CurrencyName = c?.Currency?.Name ?? string.Empty;
            copy(v, d);
            return toEntity(d);
        }
    }
}
