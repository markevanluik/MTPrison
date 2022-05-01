using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class CountryCurrencyViewFactoryTests : ViewFactoryTests<CountryCurrencyViewFactory, CountryCurrencyView, CountryCurrency, CountryCurrencyData> {
        protected override CountryCurrency toObject(CountryCurrencyData d) => new(d);
    }
}
