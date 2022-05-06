using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class CountryCurrencyViewFactoryTests
        : SealedClassTests<CountryCurrencyViewFactory, BaseViewFactory<CountryCurrencyView, CountryCurrency, CountryCurrencyData>> {

        [TestMethod] public void CreateTest() { }

        [TestMethod] public void CreateViewTest() {
            var d = GetRandom.Value<CountryCurrencyData>();
            var e = new CountryCurrency(d);
            var v = new CountryCurrencyViewFactory().Create(e);
            isNotNull(v);
            arePropertiesEqual(v, e);
        }

        [TestMethod] public void CreateEntityTest() {
            var v = GetRandom.Value<CountryCurrencyView>();
            var e = new CountryCurrencyViewFactory().Create(v);
            isNotNull(e);
            arePropertiesEqual(e, v);
        }
    }
}
