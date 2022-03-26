using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Pages {
    public class CurrenciesPage : BasePage<CurrencyView, Currency, ICurrenciesRepo> {
        public CurrenciesPage(ICurrenciesRepo r) : base(r) { }
        protected override Currency toObject(CurrencyView? item) => new CurrencyViewFactory().Create(item);
        protected override CurrencyView toView(Currency? entity) => new CurrencyViewFactory().Create(entity);
    }
}
