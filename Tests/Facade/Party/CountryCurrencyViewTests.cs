using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Facade;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class CountryCurrencyViewTests : SealedClassTests<CountryCurrencyView, IsoNamedView> {
        [TestMethod] public void CountryIdTest() => isRequired<string>();
        [TestMethod] public void CurrencyIdTest() => isRequired<string>();
        [TestMethod] public void CountryNameTest() => isDisplayNamed<string>("Country");
        [TestMethod] public void CurrencyNameTest() => isDisplayNamed<string>("Currency");
        [TestMethod] public void NameTest() => isDisplayNamed<string>("Symbol");

    }
}
