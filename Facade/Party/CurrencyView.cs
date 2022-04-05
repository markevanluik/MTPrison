using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Facade.Party {
    public class CurrencyView : IsoCommonView { }
    public sealed class CurrencyViewFactory : BaseViewFactory<CurrencyView, Currency, CurrencyData> {
        protected override Currency toEntity(CurrencyData d) => new(d);
    }
}
