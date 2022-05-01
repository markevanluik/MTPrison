using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class CurrencyViewFactoryTests : ViewFactoryTests<CurrencyViewFactory, CurrencyView, Currency, CurrencyData> {
        protected override Currency toObject(CurrencyData d) => new(d);
    }
}
