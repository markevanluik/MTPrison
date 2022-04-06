using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Pages.Party {
    public class CurrenciesPage : PagedPage<CurrencyView, Currency, ICurrenciesRepo> {
        public CurrenciesPage(ICurrenciesRepo r) : base(r) { }
        protected override Currency toObject(CurrencyView? item) => new CurrencyViewFactory().Create(item);
        protected override CurrencyView toView(Currency? entity) => new CurrencyViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CurrencyView.Code),
            nameof(CurrencyView.Name),
            nameof(CurrencyView.NativeName)
        };
    }
}
