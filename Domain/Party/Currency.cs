using MTPrison.Data.Party;

namespace MTPrison.Domain.Party {
    public interface ICurrenciesRepo : IRepo<Currency> { }
    public sealed class Currency : Entity<CurrencyData>{
        public Currency() : this(new CurrencyData()) { }
        public Currency(CurrencyData d) : base(d) { }
        public string? Code => getValue(Data?.Code);
        public string? Name => getValue(Data?.Name);
        public string? NativeName => getValue(Data?.NativeName);
    }
}
