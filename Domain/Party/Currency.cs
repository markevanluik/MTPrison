using MTPrison.Data.Party;

namespace MTPrison.Domain.Party {
    public interface ICurrenciesRepo : IRepo<Currency> { }
    public sealed class Currency : CommonEntity<CurrencyData>{
        public Currency() : this(new CurrencyData()) { }
        public Currency(CurrencyData d) : base(d) { }
    }
}
